using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CookComputing.XmlRpc;
using MylarSideCar.Manager.Configs;
using NLog;

namespace MylarSideCar.Manager.RTorrent
{
    public class RTorrentProxy : IRTorrentProxy
    {
        private readonly Logger _logger;

        public RTorrentProxy(Logger logger)
        {
            _logger = logger;
        }

        public string GetVersion(RTorrentConfig settings)
        {
            _logger.Debug("Executing remote method: system.client_version");

            var client = BuildClient(settings);

            var version = client.GetVersion();

            return version;
        }

        public List<RTorrentTorrent> GetTorrents(RTorrentConfig settings)
        {
            _logger.Debug("Executing remote method: d.multicall2");

            var client = BuildClient(settings);
            var ret = client.TorrentMulticall("", "",
                "d.name=", // string
                "d.hash=", // string
                "d.base_path=", // string
                "d.custom1=", // string (label)
                "d.size_bytes=", // long
                "d.left_bytes=", // long
                "d.down.rate=", // long (in bytes / s)
                "d.ratio=", // long
                "d.is_open=", // long
                "d.is_active=", // long
                "d.complete="); //long

            var items = new List<RTorrentTorrent>();
            foreach (object[] torrent in ret)
            {
                var labelDecoded = System.Web.HttpUtility.UrlDecode((string)torrent[3]);

                var item = new RTorrentTorrent();
                item.Name = (string)torrent[0];
                item.Hash = (string)torrent[1];
                item.Path = (string)torrent[2];
                item.Category = labelDecoded;
                item.TotalSize = (long)torrent[4];
                item.RemainingSize = (long)torrent[5];
                item.DownRate = (long)torrent[6];
                item.Ratio = (long)torrent[7];
                item.IsOpen = Convert.ToBoolean((long)torrent[8]);
                item.IsActive = Convert.ToBoolean((long)torrent[9]);
                item.IsFinished = Convert.ToBoolean((long)torrent[10]);

                items.Add(item);
            }

            return items;
        }

        public void AddTorrentFromUrl(string torrentUrl, string label, RTorrentPriority priority, string directory, bool doNotStart, RTorrentConfig settings)
        {
            _logger.Debug("Adding Torrent From URL");

            var client = BuildClient(settings);

            var response = -1;

            if (doNotStart)
            {
                _logger.Debug("Executing remote method load.normal");
                response = client.Load("", torrentUrl, GetCommands(label, priority, directory));
            }
            else
            {
                _logger.Debug("Executing remote method load.start");
                response = client.LoadStart("", torrentUrl, GetCommands(label, priority, directory));
            }

            if (response != 0)
            {
                throw new Exception("Could not add torrent:" + torrentUrl);
            }
        }

        public void AddTorrentFromFile(string fileName, byte[] fileContent, string label, RTorrentPriority priority, string directory, bool doNotStart, RTorrentConfig settings)
        {
            _logger.Debug("Loading Torrent from File");

            var client = BuildClient(settings);

            var response = -1;

            if (doNotStart)
            {
                _logger.Debug("Executing remote method load.raw");
                response = client.LoadRaw("", fileContent, GetCommands(label, priority, directory));
            }
            else
            {
                _logger.Debug("Executing remote method load.raw_start");
                response = client.LoadRawStart("", fileContent, GetCommands(label, priority, directory));
            }

            if (response != 0)
            {
                throw new Exception("Could not add torrent:" + fileName);
            }
        }

        public void RemoveTorrent(string hash, RTorrentConfig settings)
        {
            _logger.Debug("Executing remote method: d.erase");

            var client = BuildClient(settings);

            var response = client.Remove(hash);
            if (response != 0)
            {
                throw new Exception("Could not remove torrent:"+ hash);
            }
        }

        private string[] GetCommands(string label, RTorrentPriority priority, string directory)
        {
            var result = new List<string>();

            if (!string.IsNullOrWhiteSpace( label ))
            {
                result.Add("d.custom1.set=" + label);
            }

            if (priority != RTorrentPriority.Normal)
            {
                result.Add("d.priority.set=" + (int)priority);
            }

            if (!string.IsNullOrWhiteSpace(directory))
            {
                result.Add("d.directory.set=" + directory);
            }

            return result.ToArray();
        }

        public bool HasHashTorrent(string hash, RTorrentConfig settings)
        {
            _logger.Debug("Executing remote method: d.name");

            var client = BuildClient(settings);

            try
            {
                var name = client.GetName(hash);
                if (string.IsNullOrWhiteSpace( name )) return false;
                bool metaTorrent = name == (hash + ".meta");
                return !metaTorrent;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private IRTorrent BuildClient(RTorrentConfig settings)
        {
            var client = XmlRpcProxyGen.Create<IRTorrent>();

            client.Url =
                $@"{(settings.UseSsl ? "https" : "http")}://{settings.Host}:{settings.Port}/{settings.UrlBase}";

            client.EnableCompression = true;

            if (!string.IsNullOrWhiteSpace(settings.Username ))
            {
                client.Credentials = new NetworkCredential(settings.Username, settings.Password);
            }

            return client;
        }
    }
}

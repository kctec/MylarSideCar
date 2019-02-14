using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MylarSideCar.Manager.Configs;

namespace MylarSideCar.Manager.RTorrent
{
    public interface IRTorrentProxy
    {
        string GetVersion(RTorrentConfig settings);
        List<RTorrentTorrent> GetTorrents(RTorrentConfig settings);

        void AddTorrentFromUrl(string torrentUrl, string label, RTorrentPriority priority, string directory,
            bool doNotStart, RTorrentConfig settings);

        void AddTorrentFromFile(string fileName, byte[] fileContent, string label, RTorrentPriority priority,
            string directory, bool doNotStart, RTorrentConfig settings);
        void RemoveTorrent(string hash, RTorrentConfig settings);
        bool HasHashTorrent(string hash, RTorrentConfig settings);
    }
}

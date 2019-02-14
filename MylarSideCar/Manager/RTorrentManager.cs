using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MylarSideCar.Manager.Configs;
using MylarSideCar.Manager.RTorrent;
using MylarSideCar.Model;
using NLog;

namespace MylarSideCar.Manager
{
    public class RTorrentManager
    {
        private static readonly Logger Logger = new NullLogger(new LogFactory());

        public static void AddTorrent(TorzNabResult torsNabResult)
        {
            var config = ConfigManager.GetConfig<RTorrentConfig>();

            var client = new RTorrentProxy(Logger);

            client.AddTorrentFromUrl(torsNabResult.Link, "mylar", RTorrentPriority.Normal, "", false, config);
        }


    }
}

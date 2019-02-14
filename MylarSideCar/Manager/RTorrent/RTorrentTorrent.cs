using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Manager.RTorrent
{
    public class RTorrentTorrent
    {
        public string Name { get; set; }
        public string Hash { get; set; }
        public string Path { get; set; }
        public string Category { get; set; }
        public long TotalSize { get; set; }
        public long RemainingSize { get; set; }
        public long DownRate { get; set; }
        public long Ratio { get; set; }
        public bool IsFinished { get; set; }
        public bool IsOpen { get; set; }
        public bool IsActive { get; set; }
    }
}

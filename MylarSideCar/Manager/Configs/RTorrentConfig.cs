﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Manager.Configs
{
    public class RTorrentConfig
    {
        public bool UseSsl { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string UrlBase { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

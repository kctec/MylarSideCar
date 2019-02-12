using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Manager
{
    [Serializable]
    public class SabConfig
    {
        public string HostUrl { get; set; }
        public string ApIkey { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
   
        public string Root { get; set; }

        public int ActivePollInterval { get; set; }
        public int InactivePollInterval { get; set; }

        public bool Https { get; set; }

        public int Port { get; set; }

    }
}

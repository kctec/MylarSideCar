using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Manager.Configs
{
    [Serializable]
    public class TorzNabConfig
    {
        public string TorzNabName_1 { get; set; }
        public string TorzNabURL_1 { get; set; }
        public string TorzNabApiKey_1 { get; set; }
        public bool TorzNabEnabled_1 { get; set; }

        public string TorzNabName_2 { get; set; }
        public string TorzNabURL_2 { get; set; }
        public string TorzNabApiKey_2 { get; set; }
        public bool TorzNabEnabled_2 { get; set; }

        public string TorzNabName_3 { get; set; }
        public string TorzNabURL_3 { get; set; }
        public string TorzNabApiKey_3 { get; set; }
        public bool TorzNabEnabled_3 { get; set; }

        public string TorzNabName_4 { get; set; }
        public string TorzNabURL_4 { get; set; }
        public string TorzNabApiKey_4 { get; set; }
        public bool TorzNabEnabled_4 { get; set; }


        public string LinkSubFind { get; set; }

        public string LinkSubReplace { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model.ComicVine
{
    public class CvVolumeResponse : CvResponse
    {
 
        [Newtonsoft.Json.JsonProperty(PropertyName = "results")]
        public CvVolume  Volume { get; set; }
 
    }
}

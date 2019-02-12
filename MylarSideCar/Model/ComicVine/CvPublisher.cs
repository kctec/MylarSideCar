using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model.ComicVine
{
    public class CvPublisher
    {

        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "image")]
        public CvImage Image { get; set; }
    }
}

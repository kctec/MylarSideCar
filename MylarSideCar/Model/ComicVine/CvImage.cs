using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model.ComicVine
{
    public class CvImage
    {

        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "icon_url")]
        public string IconUrl { get; set; }

     

    }
}

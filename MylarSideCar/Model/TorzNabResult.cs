using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model
{
    [Serializable]
    public class TorzNabResult
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "guid")]
        public string Guid { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "jackettindexer")]
        public string JackettIndexer { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "comments")]
        public string Comments { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "pubDate")]
        public string PublishDate { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "size")]
        public string Size { get; set; }


        [Newtonsoft.Json.JsonProperty(PropertyName = "grabs")]
        public string Grabs { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }
}
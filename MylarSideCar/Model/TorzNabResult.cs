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

        public List<string> Categories { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "files")]
        public string Files { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

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

        [Newtonsoft.Json.JsonProperty(PropertyName = "seeders")]
        public string Seeders { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "peers")]
        public string Peers { get; set; }
 

        public string BindingName =>  "(" + Seeders +"/" + Peers + ") - " + Title + " - (" + JackettIndexer + ")";


    }
}
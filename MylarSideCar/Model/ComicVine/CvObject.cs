using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model.ComicVine
{
    public class CvObject
    {

        [Newtonsoft.Json.JsonProperty(PropertyName = "api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "count")]
        public string Count { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "site_detail_url")]
        public string SiteDetailUrl { get; set; }
    }
}

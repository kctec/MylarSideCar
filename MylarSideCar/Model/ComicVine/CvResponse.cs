using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model.ComicVine
{
    public class CvResponse
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "limit")]
        public int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "offset")]
        public int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "number_of_page_results")]
        public int NumberOfPageResults { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "number_of_total_results")]
        public int NumberOfTotalResults { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "status_code")]
        public int StatusCode { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
    }
}

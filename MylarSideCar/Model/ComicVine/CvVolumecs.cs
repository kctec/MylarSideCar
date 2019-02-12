using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model.ComicVine
{
    public class CvVolume 
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "api_detail_url")]
        public string ApiDetailUrl { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "count_of_issues")]
        public int CountOfIssues { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "date_added")]
        public string DateAdded { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "date_last_updated")]
        public string DateLastAdded { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "site_detail_url")]
        public string SiteDetailUrl { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "start_year")]
        public string StartYear { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "characters")]
        public List<CvObject> Characters { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "objects")]
        public List<CvObject> Objects { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "people")]
        public List<CvObject> People { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "issues")]
        public List<CvIssue> Issues { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "publisher")]
        public CvObject Publisher { get; set; }
    }
}

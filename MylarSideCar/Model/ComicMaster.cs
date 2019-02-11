using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model
{
    public class ComicMaster
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "comic")]
        public List<Comic> Comics { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "issues")]
        public List<Issue> Issues { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "annuals")]
        public List<Issue> Annuals { get; set; }

    }
}

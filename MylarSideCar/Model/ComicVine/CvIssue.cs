using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model.ComicVine
{
    public class CvIssue : CvObject
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "issue_number")]
        public string IssueNumber { get; set; }
    }
}

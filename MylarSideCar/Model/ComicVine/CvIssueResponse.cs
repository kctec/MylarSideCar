using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model.ComicVine
{
    public class CvIssueResponse: CvResponse
    {
 
        [Newtonsoft.Json.JsonProperty(PropertyName = "results")]
        public CvIssue  Issue { get; set; }
 
    }
}

using MylarSideCar.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model
{
    public class Issue  : Entity
    {
        public string Status { get; set; }
        public string ComicSize { get; set; }
        public string ComicName { get; set; }
        public string IssueID { get; set; }
        public string AltIssueNumber { get; set; }
        public string IssueDate { get; set; }
        public string ImageURL { get; set; }
        public string DigitalDate { get; set; }
        public string inCacheDIR { get; set; }
        public string IssueDate_Edit { get; set; }
        public string ImageURL_ALT { get; set; }
        public string ReleaseDate { get; set; }
        public string ArtworkURL { get; set; }

        public string Issue_Number { get; set; }
        public int Int_IssueNumber { get; set; }
        public string IssueName { get; set; }
 
        public string Type { get; set; }
        public string DateAdded { get; set; }

        public string BindingName
        {
            get
            {
                if (Status == "Downloaded")
                {
                    return  Issue_Number.PadLeft(3,'0')+ " - " + IssueName;
                }

                return Issue_Number.PadLeft(3, '0') + " - " + IssueName;
            }
        }
    }
}

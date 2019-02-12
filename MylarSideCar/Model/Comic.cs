using MylarSideCar.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model
{
    public class Comic : Book
    {
        public string not_updated_db { get; set; }
        public string QUALtype { get; set; }

        public string ComicName_Filesafe { get; set; }

        public string ComicLocation { get; set; }

        public string LatestIssueID { get; set; }

        public string UseFuzzy { get; set; }

        public string SortOrder { get; set; }

        public string TorrentID_32P { get; set; }

        public string ComicSortName { get; set; }

        public string QUALscanner { get; set; }

        public string QUALalt_vers { get; set; }

        public string ForceContinuing { get; set; }

        public string DateAdded { get; set; }

        public string Corrected_Type { get; set; }

        public string ComicImageALTURL { get; set; }

        public string IncludeExtras { get; set; }

        public string LastUpdated { get; set; }

        public string AllowPacks { get; set; }

        public int Have { get; set; }

        public int Total { get; set; }

        public string Collects { get; set; }

        public string ComicImage { get; set; }

        public string AlternateSearch { get; set; }
    }
}

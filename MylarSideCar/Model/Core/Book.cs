using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Model.Core
{
    public abstract class Book : Entity
    {
  
        public string DynamicComicName { get; set; }
        public int? Corrected_SeriesYear { get; set; }
        public int ComicYear { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }

        public DateTime LatestDate { get; set; }

        public string ComicPublished { get; set; }

        public string ComicName { get; set; }

        public string ComicImageURL { get; set; }

        public string DetailURL { get; set; }
    }
}

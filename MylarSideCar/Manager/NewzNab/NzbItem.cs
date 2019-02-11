using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MylarSideCar.Manager.NewzNab
{
    public abstract class NzbItem
    {
        static ColorConverter ColConv = new ColorConverter();

        public static Color NewBackgroundColor = (Color)ColConv.ConvertFrom("#C6FFC6"); //green-ish
        public static Color DownloadedBackgroundColor = Color.White;
        public static Color ErrorBackgroundColor = (Color)ColConv.ConvertFrom("#FFC3C6"); //red-ish

        public object UniqueID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string DownloadLink { get; set; }
        public string Size { get; set; }
        public string Age { get; set; }

        public DateTime PostedDate { get; set; }

        public bool HasBeenDownloaded { get; set; }
        public bool HasMissingParts { get; set; }
        public virtual Color BackgroundColor
        {
            get
            {
                if (HasBeenDownloaded) // downloaded before?
                    return NzbItem.DownloadedBackgroundColor;
                else if (HasMissingParts) // has missing parts?
                    return NzbItem.ErrorBackgroundColor;
                else
                    return NzbItem.NewBackgroundColor;
            }
        }

        public int PercentAvailable { get; set; }
        public virtual bool HasNFO { get { return false; } }
    }

}

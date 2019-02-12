using MylarSideCar.Model.Core;
 

namespace MylarSideCar.Model
{
    public class Title : Book
    {
 
        public int? Have { get; set; }

        public int? Total { get; set; }

        public string BindingName 
        {
            get{
                return "(" + ComicYear + ") - " + ComicName + " - [" + Have + "/" + Total + "]";
            }
        }

    }
}

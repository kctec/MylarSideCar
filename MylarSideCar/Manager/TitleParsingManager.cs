using MylarSideCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MylarSideCar.Manager
{
    public class TitleParsingManager
    {

        public static bool TitleMatch(string title, Issue issue, Comic comic)
        {
            var fixedTitle = Regex.Replace(title, "[^a-zA-Z0-9_]+", " ");

            //check for comic name 
            var values = fixedTitle.Split(char.Parse(" "));
 
            if (!title.Contains(comic.ComicYear.ToString()))
            {
                return false;
            }

            return title.Replace(comic.ComicYear.ToString(), "").Contains(issue.Issue_Number) && values.All(value => title.ToLower().Contains(value.ToLower()));
        }
    }
}

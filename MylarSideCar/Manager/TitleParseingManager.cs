using MylarSideCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MylarSideCar.Manager
{
    public class TitleParseingManager
    {

        public static bool TitleMatch(string title, Issue issue, Comic comic, bool year, bool issueNumber)
        {
            string replacestr = Regex.Replace(title, "[^a-zA-Z0-9_]+", " ");

            //check for comic name 
            string[] values = replacestr.Split(char.Parse(" "));
 
            if (!title.Contains(comic.ComicYear.ToString()))
            {
                return false;
            }

            if (!title.Replace(comic.ComicYear.ToString(), "").Contains(issue.Issue_Number.ToString()))
            {
                return false;
            }


            foreach (string value in values)
            {
                if (!title.ToLower().Contains(value.ToLower()))
                {
                    return false;
                }
 
            }
            return true;
        }
    }
}

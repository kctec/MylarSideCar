using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Web;

namespace MylarSideCar.Manager.NewzNab
{

    public class NewzNabCapabilities
    {
        //Public Properties
        public int MaxResults;
        public int DefaultResults;
        public int Retention;

        public bool SearchAvail;
        public bool TvSearchAvail;
        public bool MovieSearchAvail;
        public bool AudioSearchAvail;

        public Dictionary<int, string> Categories = new Dictionary<int, string>();
        public List<UsenetGroup> Groups = new List<UsenetGroup>();
        public List<NewzNabGenre> Genres = new List<NewzNabGenre>();

        public static NewzNabCapabilities ParseXMLResponse(string XMLResponse)
        {
            XmlDocument Capabilities = new XmlDocument();
            Capabilities.LoadXml(XMLResponse);
            return ParseXmlResponse(Capabilities);
        }

        public static NewzNabCapabilities ParseXmlResponse(XmlDocument xmlResponse)
        {
            NewzNabCapabilities Result = new NewzNabCapabilities();

            //Basic Capabilities
            Result.MaxResults = Convert.ToInt32(xmlResponse.SelectSingleNode("/caps/limits").Attributes["max"].Value);
            Result.DefaultResults = Convert.ToInt32(xmlResponse.SelectSingleNode("/caps/limits").Attributes["default"].Value);
            Result.Retention = Convert.ToInt32(xmlResponse.SelectSingleNode("/caps/retention").Attributes["days"].Value);

            //Search Capabilities
            Result.SearchAvail = YesNoToBool(xmlResponse.SelectSingleNode("/caps/searching/search").Attributes["available"].Value);
            Result.TvSearchAvail = YesNoToBool(xmlResponse.SelectSingleNode("/caps/searching/tv-search").Attributes["available"].Value);
            Result.MovieSearchAvail = YesNoToBool(xmlResponse.SelectSingleNode("/caps/searching/movie-search").Attributes["available"].Value);
            Result.AudioSearchAvail = YesNoToBool(xmlResponse.SelectSingleNode("/caps/searching/audio-search").Attributes["available"].Value);

            //Categories
            foreach (XmlNode cat in xmlResponse.SelectNodes("caps/categories/category"))
            {
                Result.Categories.Add(Convert.ToInt32(cat.Attributes["id"].Value), HttpUtility.HtmlDecode(cat.Attributes["name"].Value));
                foreach (XmlNode subCat in cat.ChildNodes)
                {
                    Result.Categories.Add(Convert.ToInt32(subCat.Attributes["id"].Value), HttpUtility.HtmlDecode(cat.Attributes["name"].Value + "\\" + subCat.Attributes["name"].Value));
                }
            }

            //Groups
            foreach (XmlNode group in xmlResponse.SelectNodes("caps/groups/group"))
            {
                if (group.Attributes == null) continue;
                var currentGroup = new UsenetGroup
                {
                    ID = Convert.ToInt32(group.Attributes["id"].Value),
                    Name = HttpUtility.HtmlDecode(group.Attributes["name"].Value),
                    Description = group.Attributes["description"].Value
                };
                DateTime.TryParse(group.Attributes["lastupdate"].Value, out currentGroup.LastUpdate);
                Result.Groups.Add(currentGroup);
            }

            //Genres
            foreach (XmlNode genre in xmlResponse.SelectNodes("caps/genres/genres"))
            {
                if (genre.Attributes != null)
                {
                    var currentGenre = new NewzNabGenre
                    {
                        ID = Convert.ToInt32(genre.Attributes["id"].Value),
                        CategoryID = Convert.ToInt32(genre.Attributes["categoryid"].Value)
                    };
                    currentGenre.Name = HttpUtility.HtmlDecode(Result.Categories[currentGenre.CategoryID] + "\\" + genre.Attributes["name"].Value);
                    Result.Genres.Add(currentGenre);
                }
            }

            return Result;
        }

        private static bool YesNoToBool(string yesNo)
        {
            if (yesNo == null) throw new ArgumentNullException(nameof(yesNo));
            switch (yesNo.ToLower())
            {
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    return false;
            }
        }


    }

    public struct UsenetGroup
    {
        public int ID;
        public string Name;
        public string Description;
        public DateTime LastUpdate;

        public override string ToString()
        {
            return Name;
        }
    }

    public struct NewzNabGenre
    {
        public int ID;
        public int CategoryID;
        public string Name;

        public override string ToString()
        {
            return Name;
        }
    }
}

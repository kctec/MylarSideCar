using MylarSideCar.Manager.Configs;
using MylarSideCar.Manager.NewzNab;
using MylarSideCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace MylarSideCar.Manager
{
    public class NewzNabManager
    {

 
        private static NewzNabSource GetSource(string host, string apiKey )
        {
            return new NewzNabSource(host, true, apiKey);
        }

        public static List<NewzNabSearchResult> SearchForIssue(Issue issue, Comic comic, string host, string apiKey, string name)
        {
            var query = new NewzNabQuery {RequestedFunction = Functions.Search};
            query.Groups.Add("alt.binaries.ebook");
            query.Groups.Add("alt.binaries.comics");
            query.Groups.Add("alt.binaries.comics.dcp");
            query.Groups.Add("alt.binaries.comics.repost");
            query.Groups.Add("alt.binaries.pictures.comics");
            query.Groups.Add("alt.binaries.pictures.comics.dcp");
            query.Groups.Add("alt.binaries.pictures.comics.repost");
            query.Groups.Add(" alt.binaries.pictures.comics.reposts");
            query.Groups.Add("alt.binaries.manga");
            query.Groups.Add("alt.binaries.mangas");
            query.Groups.Add("alt.binaries.pictures.comics.complete");
            query.Query = Regex.Replace(comic.ComicName, "[^a-zA-Z0-9_]+", " ");

            var rawData = GetSource(host,apiKey).Search(query);

            var parsedResults = new List<NewzNabSearchResult>();

            foreach (var result in rawData)
            {
                if (!result.Category.ToLower().Contains("comic") &&
                    !result.Category.ToLower().Contains("book")) continue;
                if (!TitleParsingManager.TitleMatch(result.Title, issue, comic)) continue;
 
                result.Provider = name;
                parsedResults.Add(result);

            }

            return parsedResults;
        }

    }
}

using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using MylarSideCar.Manager.Configs;
using MylarSideCar.Model.ComicVine;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using MylarSideCar.Model;

namespace MylarSideCar.Manager
{
    public class TorzNabManager
    {
        

        private static RestClient GetRestClient(string host)
        {
            return new RestClient(host);
        }

        public static List<TorzNabResult> SearchIssue( Comic comic, string host, string apiKey)
        {
            return SearchIssue(null, comic, host, apiKey);
        }

        public static List<TorzNabResult> SearchIssue(Issue issue, Comic comic, string host, string apiKey)
        {
            if (!ConfigManager.HasValue<MylarConfig>()) return null;
            var request = new RestRequest("/", Method.GET);
            request.AddParameter("apikey", apiKey);
            request.AddParameter("cat", "100094,8020,100061,10020");
            string query = Regex.Replace(comic.ComicName, "[^a-zA-Z0-9_]+", " ");
            request.AddParameter("q", query);

            var response = GetRestClient(host).Execute(request);

            return response.StatusCode != HttpStatusCode.OK
                ? new List<TorzNabResult>()
                : ParseTorzNabXml(response.Content)
                    .Where(result => TitleParsingManager.TitleMatch(result.Title, issue, comic)).ToList();
        }

        private static IEnumerable<TorzNabResult> ParseTorzNabXml(string content)
        {
            var list = new List<TorzNabResult>();
            var doc = new XmlDocument();
            doc.LoadXml(content);

            var items = doc.SelectNodes("//item");
            if (items == null)
            {
                return list;
            }

            foreach (XmlNode item in items)
            {
                var torzNabResult = new TorzNabResult();
 
                foreach (XmlNode attribute in item.ChildNodes)
                {
                    switch (attribute.Name)
                    {
                        case "title":
                            torzNabResult.Title = attribute.InnerText;
                            continue;
                        case "jackettindexer":
                            torzNabResult.JackettIndexer = attribute.InnerText;
                            continue;
                        case "files":
                            torzNabResult.Files = attribute.InnerText;
                            continue;
                        case "guid":
                            torzNabResult.Guid = attribute.InnerText;
                            continue;
                        case "grabs":
                            torzNabResult.Grabs = attribute.InnerText;
                            continue;
                        case "link":
                            torzNabResult.Link = attribute.InnerText;
                            continue;
                        case "description":
                            torzNabResult.Description = attribute.InnerText;
                            continue;
                        case "comments":
                            torzNabResult.Comments = attribute.InnerText;
                            continue;
                        case "size":
                            torzNabResult.Size = attribute.InnerText;
                            continue;
                        case "pubDate":
                            torzNabResult.PublishDate = attribute.InnerText;
                            continue;

                    }


                    if (attribute.Attributes?.GetNamedItem("name")?.InnerText == "category")
                    {
                        if (torzNabResult.Categories == null)
                        {
                            torzNabResult.Categories = new List<string>();
                        }
                        torzNabResult.Categories.Add(attribute.Attributes?.GetNamedItem("value")?.InnerText);
                    }

                    if (attribute.Attributes?.GetNamedItem("name")?.InnerText == "peers")
                    {
                        torzNabResult.Peers = attribute.Attributes?.GetNamedItem("value")?.InnerText;
                    }

                    if (attribute.Attributes?.GetNamedItem("name")?.InnerText == "seeders")
                    {
                        torzNabResult.Seeders = attribute.Attributes?.GetNamedItem("value")?.InnerText;
                    }
                }


                list.Add(torzNabResult);
            }


            return list;
        }




    }
}

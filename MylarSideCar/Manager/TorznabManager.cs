using System.Collections.Generic;
using MylarSideCar.Manager.Configs;
using MylarSideCar.Model.ComicVine;
using Newtonsoft.Json;
using RestSharp;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MylarSideCar.Model;

namespace MylarSideCar.Manager
{
    public class TorzNabManager
    {
        

        private static RestClient GetRestClient(string host)
        {
            return new RestClient(host);
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
            var content = response.Content;
            /*var rawData = GetSource(host, apiKey).Search(query);
            request.AddParameter("q", GetConfig().APIkey);
            request.AddParameter("cmd", "getIndex");

            var response = GetRestClient().Execute(request);
            var content = response.Content;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }*/
            return null;

        }




    }
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using MylarSideCar.Manager.Configs;
using MylarSideCar.Model;
using Newtonsoft.Json;
using NLog;
using RestSharp;

namespace MylarSideCar.Manager
{
    public class MylarManager
    {
        private static MylarConfig _mylarConfig;
        private static RestClient _client;
       
        private static RestClient GetRestClient()
        {
            return _client ?? (_client = new RestClient(GetConfig().HostURL));
        }

        private static MylarConfig GetConfig()
        {
            return _mylarConfig ?? (_mylarConfig = ConfigManager.GetConfig<MylarConfig>());
        }


        public static List<Title> GetTitles()
        {

            if (!ConfigManager.HasValue<MylarConfig>()) return null;
            var request = new RestRequest("/", Method.GET);
            request.AddParameter("apikey", GetConfig().APIkey);
            request.AddParameter("cmd", "getIndex");

            var response = GetRestClient().Execute(request);
            var content = response.Content;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

            return JsonConvert.DeserializeObject<List<Title>>(content, jsonSerializerSettings);


        }

        public static bool AddComic(string comicId)
        {
            var request = new RestRequest("/", Method.GET);
            request.AddParameter("apikey", GetConfig().APIkey);
            request.AddParameter("cmd", "addComic");
            request.AddParameter("id", comicId);

            var response = GetRestClient().Execute(request);
            string content;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                content = response.Content;
                Debug.Write(content);
                return true;
            }
            content = response.Content;
            Debug.Write(content);
            return false;
        }


        public static bool DeleteComic(string comicId )
        {
            var request = new RestRequest("/", Method.GET);
            request.AddParameter("apikey", GetConfig().APIkey);
            request.AddParameter("cmd", "delComic");
            request.AddParameter("id", comicId);

            var response = GetRestClient().Execute(request);
            string content;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                content = response.Content;
                Debug.Write(content);
                return true;
            }
            content = response.Content;
            Debug.Write(content);
            return false;
        }

        public static ComicMaster GetComic(string comicId)
        {
            var request = new RestRequest("/", Method.GET);
            request.AddParameter("apikey", GetConfig().APIkey);
            request.AddParameter("cmd", "getComic");
            request.AddParameter("id", comicId);

            var response = GetRestClient().Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }
            var content = response.Content;

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            var c = JsonConvert.DeserializeObject<ComicMaster>(content, jsonSerializerSettings);

            return c;
        }
    }
}
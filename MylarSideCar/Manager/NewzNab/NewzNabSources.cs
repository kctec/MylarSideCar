using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using MylarSideCar.Model;

namespace MylarSideCar.Manager.NewzNab
{
 
    public class NewzNabSource
    {
        //Configuration Variables
        public string ApiKey { get; private set; }
        public Uri Apiurl { get; private set; }
        public bool UseSsl { get; private set; }
        public EncodingType Encoding { get; private set; }

        //Storage Variables
        public NewzNabCapabilities Capabilities { get; private set; }

        //Enums
        public enum EncodingType
        {
            JSON,
            XML
        }

        //Constructors
        #region Constructors
        public NewzNabSource(string URL)
        {
            ApiKey = "";
            Encoding = EncodingType.XML;
            UseSsl = false;
            Apiurl = UrLtoNewzNabUri(URL, UseSsl);
        }

        public NewzNabSource(string URL, bool SSL)
        {
            ApiKey = "";
            Encoding = EncodingType.XML;
            UseSsl = SSL;
            Apiurl = UrLtoNewzNabUri(URL, UseSsl);
        }

        public NewzNabSource(string URL, bool SSL, string API_Key)
        {
            ApiKey = API_Key;
            Encoding = EncodingType.XML;
            UseSsl = SSL;
            Apiurl = UrLtoNewzNabUri(URL, UseSsl);
        }

        public NewzNabSource(string URL, bool SSL, string API_Key, EncodingType UseEncodingType)
        {
            ApiKey = API_Key;
            Encoding = UseEncodingType;
            UseSsl = SSL;
            Apiurl = UrLtoNewzNabUri(URL, UseSsl);
        }


        #endregion Constructors

        public bool GetCapabilities()
        {
            NewzNabQuery capsQuery = new NewzNabQuery();
            capsQuery.RequestedFunction = Functions.Caps;
            XmlDocument response = DoQuery(capsQuery);
            Capabilities = NewzNabCapabilities.ParseXmlResponse(response);
            return true;
        }

        public static Uri UrLtoNewzNabUri(string URL, bool SSL)
        {
            var builder = new UriBuilder(URL);
            if (SSL)
            {
                builder.Scheme = Uri.UriSchemeHttps;
                builder.Port = -1;
            }
            else
            {
                builder.Scheme = Uri.UriSchemeHttp;
                builder.Port = -1;
            }
            if (!builder.Path.EndsWith("api"))
            {
                if (!builder.Path.EndsWith("/"))
                {
                    builder.Path += "/";
                }
                builder.Path = string.Concat(builder.Path, "api");
            }
            builder.Query = "";
            return builder.Uri;
        }

        private XmlDocument DoQuery(NewzNabQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            var queryUri = new UriBuilder(Apiurl);
            switch (query.RequestedFunction)
            {
                case Functions.Caps:
                    queryUri.Query = "t=caps&o=xml";
                    break;
                case Functions.Register:
                    break;
                case Functions.Search:
                    queryUri.Query = BuildGenericQueryString(query);
                    break;
                case Functions.TvSearch:
                    break;
                case Functions.MovieSearch:
                    break;
                case Functions.MusicSearch:
                    break;
                case Functions.BookSearch:
                    break;
                case Functions.Details:
                    break;
                case Functions.Getnfo:
                    break;
                case Functions.Get:
                    break;
                case Functions.CartAdd:
                    break;
                case Functions.CartDel:
                    break;
                case Functions.Comments:
                    break;
                case Functions.CommentsAdd:
                    break;
                case Functions.User:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            XmlDocument xmlResponse = new XmlDocument();
            xmlResponse.Load(queryUri.Uri.ToString());
            return xmlResponse;
        }

        private string BuildGenericQueryString(NewzNabQuery Query)
        {
            var result = new StringBuilder();
            result.Append("t=search");
            if (ApiKey != "") { result.Append("&apikey=" + ApiKey); }
            if (Query.Query != "") { result.Append("&q=" + Query.Query); }
             result.Append("&offset=" + Query.Offset.ToString()); 
            if (Query.Groups.Count > 0)
            {
                result.Append("&group=");
                result.Append(string.Join(",", Query.Groups));
            }

            if (Query.Categories.Count <= 0) return result.ToString();
            result.Append("&cat=");
            result.Append(string.Join(",", Query.Categories));
            return result.ToString();
        }

        public List<NewzNabSearchResult> Search(NewzNabQuery query)
        {
            var results = new List<NewzNabSearchResult>();
            var result = DoQuery(query);
            var items = result.SelectNodes("/rss/channel/item");
            if (items == null) return results;
            foreach (XmlNode item in items)
            {
                results.Add(NewzNabQuery.ParseItemBlock(item));
            }

            return results;
        }
    }


}

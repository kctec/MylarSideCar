using MylarSideCar.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace MylarSideCar.Manager.NewzNab
{
   

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class NewzNabQuery
    {
        public Functions RequestedFunction;
        public string Query;
        public List<string> Groups = new List<string>();
        public List<int> Categories = new List<int>();
        public int Offset;

        public static NewzNabSearchResult ParseItemBlock(XmlNode item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            var result = new NewzNabSearchResult
            {
                Title = item["title"]?.InnerText,
                Guid = item["guid"]?.InnerText,
                Link = item["link"]?.InnerText,
                CommentLink = item["comments"]?.InnerText,
                PublishDate = DateTime.Parse(item["pubDate"]?.InnerText),
                Category = item["category"]?.InnerText,
                Description = Regex.Replace(item["description"]?.InnerText.Replace(@"<br />", Environment.NewLine) ?? throw new InvalidOperationException(), "<.*?>", string.Empty).Trim(),
                NZBUrl = item["enclosure"]?.GetAttribute("url")
            };
            foreach (XmlNode attr in item.ChildNodes)
            {
                if (attr.Name != "newznab:attr") continue;
                if (attr.Attributes != null)
                    result.Attributes.Add(new KeyValuePair<string, string>(attr.Attributes["name"].Value,
                        attr.Attributes["value"].Value));
            }
            return result;
        }
    }

    public enum Functions
    {
        Caps,
        Register,
        Search,
        TvSearch,
        MovieSearch,
        MusicSearch,
        BookSearch,
        Details,
        Getnfo,
        Get,
        CartAdd,
        CartDel,
        Comments,
        CommentsAdd,
        User
    }


   
}


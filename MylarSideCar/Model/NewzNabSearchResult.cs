﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace MylarSideCar.Model
{


    public class NewzNabSearchResult
    {
        public string Title { get; set; }
        public string Guid { get; set; }
        public string Link { get; set; }
        public string CommentLink { get; set; }
        public DateTime PublishDate { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string NZBUrl { get; set; }
        public List<KeyValuePair<string, string>> Attributes = new List<KeyValuePair<string, string>>();

        public string Provider { get; set; }

        public string BindingName
        {
            get {
                return Title + " - [" + Category + "] - " + PublishDate + " - ("+ Provider + ")";
            }
        }
       
    }
}

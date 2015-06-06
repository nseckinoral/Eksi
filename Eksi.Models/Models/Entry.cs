using System;
using System.Collections.Generic;
using System.Linq;

namespace Eksi.Models
{
    public class Entry
    {
        public string Id { get; set; }
        public string AuthorName { get; set; }
        public string FavoriteCount { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
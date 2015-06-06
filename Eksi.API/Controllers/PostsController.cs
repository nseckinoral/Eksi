using Eksi.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Eksi.Controllers
{
    public class PostsController : BaseController
    {
        public async Task<List<Entry>> Get(string prefix)
        {
            var source = await GetSourceCode(prefix);
            return ParseEntry(source);
        }

        private List<Entry> ParseEntry(string source)
        {
            source = WebUtility.HtmlDecode(source);
            HtmlDocument resultat = new HtmlDocument();
            resultat.LoadHtml(source);
            List<HtmlNode> toftitle = resultat.DocumentNode
                .Descendants()
                .Where(x => x.Id == "entry-list").ToList();

            var li = toftitle[0].Descendants("li").ToList();
            List<Entry> Entry = new List<Entry>();

            foreach (var item in li)
            {
                try
                {
                    var itemText = item.InnerText;
                    itemText = itemText.Replace(Environment.NewLine, "");
                    var indexOfSharp = itemText.IndexOf('#');
                    var content = itemText.Substring(0, indexOfSharp);
                    var splitted = itemText.Substring(indexOfSharp, itemText.Length - indexOfSharp - 1).Split(' ');

                    Entry.Add(
                        new Entry()
                        {
                            Content = item.InnerText.Substring(0, item.InnerText.IndexOf('#')),
                            Id = splitted[0],
                            Date = splitted[1],
                            Time = splitted[2].Substring(0, 5),
                            AuthorName = splitted[2].Substring(5)
                        }
                    );
                }
                catch
                {
                    continue;
                }
            }
            return Entry;
        }
    }
}

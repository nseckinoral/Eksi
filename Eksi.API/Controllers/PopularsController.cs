using Eksi.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Eksi.Controllers
{
    public class PopularsController : BaseController
    {
        public async Task<List<Popular>> Get()
        {
            var source = await GetSourceCode();
            return ParsePopulars(source);
        }

        private List<Popular> ParsePopulars(string source)
        {
            source = WebUtility.HtmlDecode(source);
            HtmlDocument resultat = new HtmlDocument();
            resultat.LoadHtml(source);
            List<HtmlNode> toftitle = resultat.DocumentNode
                .Descendants()
                .Where(x => (x.Name == "ul" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("topic-list partial"))).ToList();

            var li = toftitle[0].Descendants("li").ToList();
            List<Popular> populars = new List<Popular>();

            foreach (var item in li)
            {
                try
                {
                    var link = item.Descendants("a").ToList()[0].GetAttributeValue("href", null);
                    var titleAndCommentCount = item.Descendants("a").ToList()[0].InnerText;
                    var splitted = titleAndCommentCount.Split(' ');
                    var commentCount = splitted.Last();
                    var title = titleAndCommentCount.Remove(titleAndCommentCount.Length - commentCount.Length);

                    populars.Add(
                        new Popular()
                        {
                            Url = link,
                            Title = title,
                            CommentCount = !string.IsNullOrEmpty(commentCount) ? Convert.ToInt32(commentCount) : 0
                        }
                    );
                }
                catch
                {
                    continue;
                }
            }
            return populars;
        }
    }
}

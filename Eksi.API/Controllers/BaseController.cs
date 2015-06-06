using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Eksi.Controllers
{
    public class BaseController : ApiController
    {
        protected HttpClient client;
        protected const string baseUrl = "https://www.eksisozluk.com";

        public BaseController()
        {
            client = new HttpClient();
        }

        protected async Task<string> GetSourceCode(string prefix = null)
        {
            var url = baseUrl;
            if (!string.IsNullOrEmpty(prefix))
            {
                url = baseUrl + prefix;
            }
            var source = await client.GetStringAsync(url);
            return source;
        }
    }
}

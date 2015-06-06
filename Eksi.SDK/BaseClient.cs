using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Eksi.SDK
{
    public class BaseClient<T>
    {
        protected const string baseURL = "http://eksiapi.azurewebsites.net";
        protected HttpClient client;

        public BaseClient()
        {
            client = new HttpClient();
        }

        public async Task<T> GetAsync(string prefix = null)
        {
            string url = baseURL;
            if (prefix != null)
            {
                url = baseURL + prefix;
            }
            using (var response = await client.GetAsync(url))
            {
                return await response.Content.ReadAsAsync<T>();
            }
        }
    }
}

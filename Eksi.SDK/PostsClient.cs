using Eksi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksi.SDK
{
    public class PostsClient : BaseClient<List<Entry>>
    {
        public async Task<List<Entry>> GetPostsAsync(Popular post)
        {
            return await GetAsync(String.Format("/api/posts?prefix={0}", post.Url));
        }
    }
}

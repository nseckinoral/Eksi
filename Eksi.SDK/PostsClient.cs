using Eksi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksi.SDK
{
    public class PostsClient : BaseClient<ObservableCollection<Entry>>
    {
        public async Task<ObservableCollection<Entry>> GetPostsAsync(Popular post)
        {
            return await GetAsync(String.Format("/api/posts?prefix={0}", post.Url));
        }
    }
}

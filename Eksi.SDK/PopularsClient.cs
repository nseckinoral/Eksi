using Eksi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksi.SDK
{
    public class PopularsClient : BaseClient<List<Popular>>
    {
        public async Task<List<Popular>> GetPopulars()
        {
            return await GetAsync("/api/populars");
        }
    }
}

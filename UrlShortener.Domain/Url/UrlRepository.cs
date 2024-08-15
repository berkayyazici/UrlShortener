using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Url
{
    public class UrlRepository : IUrlRepository
    {
        public Task<Url> CreateAsync(Url url)
        {
            throw new NotImplementedException();
        }

        public Task<Url> FindByLongUrlAsync(string longUrl)
        {
            throw new NotImplementedException();
        }

        public Task<Url> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Url>> GetListAsync()
        {
            throw new NotImplementedException();
        }
    }
}

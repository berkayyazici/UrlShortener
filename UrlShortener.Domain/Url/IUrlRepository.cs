using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Url
{
    public interface IUrlRepository
    {
        Task<Url> CreateAsync(Url url);
        Task<Url> FindByLongUrlAsync(string longUrl);
        Task<Url> GetAsync(Guid id);
        Task<List<Url>> GetListAsync();
    }
}

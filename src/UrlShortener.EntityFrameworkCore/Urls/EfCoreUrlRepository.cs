using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Data.EntityFrameworkCore;
using UrlShortener.Domain.Url;

namespace UrlShortener.EntityFrameworkCore.Urls
{
    public class EfCoreUrlRepository : IUrlRepository
    {
        private readonly EfContext _context;

        public EfCoreUrlRepository(EfContext efContext)
        {
            this._context = efContext;
        }

        public async Task<Url> CreateAsync(Url url)
        {
            await _context.Urls.AddAsync(url);
            await _context.SaveChangesAsync();
            return url;
        }

        public async Task<Url> FindByLongUrlAsync(string longUrl)
        {
            var dbSet = await _context.Urls.ToListAsync();
            return dbSet.FirstOrDefault(url => url.LongUrl == longUrl);
        }

        public Task<Url> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Url>> GetListAsync()
        {
            return await _context.Urls.ToListAsync();
        }
    }
}

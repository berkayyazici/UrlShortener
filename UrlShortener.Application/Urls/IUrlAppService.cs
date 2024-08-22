using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application.Urls;

namespace UrlShortener.Application.Urls
{
    public interface IUrlAppService
    {
        Task<UrlDto> GetAsync(Guid id);
        Task<List<UrlDto>> GetListAsync();
        Task<UrlDto> CreateAsync(CreateUrlDto input);
        Task UpdateAsync(Guid id, UpdateUrlDto input);
        Task DeleteAsync(Guid id);
    }
}

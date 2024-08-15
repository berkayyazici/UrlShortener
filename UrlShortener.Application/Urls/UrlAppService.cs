using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Url;
using UrlShortener.Application.Contracts.Url;
using UrlShortener.Application.Contracts;

namespace UrlShortener.Application.Urls
{
    public class UrlAppService : IUrlAppService
    {
        private readonly IUrlRepository _urlRepository;
        private readonly UrlManager _urlManager;

        public UrlAppService(IUrlRepository urlRepository, UrlManager urlManager)
        {
            _urlRepository = urlRepository;
            _urlManager = urlManager;
        }

        public async Task<UrlDto> GetAsync(Guid id)
        {
            var url = await _urlRepository.GetAsync(id);
            return new UrlDto() { ID = url.ID, LongUrl = url.LongUrl, ShortUrl = url.ShortUrl };
        }

        public async Task<List<UrlDto>> GetListAsync()
        {
            var urls = await _urlRepository.GetListAsync();
            return urls.Select(url => new UrlDto() { ID = url.ID, LongUrl= url.LongUrl, ShortUrl= url.ShortUrl }).ToList();
        }

        public async Task<UrlDto> CreateAsync(CreateUrlDto input)
        {
            var url = await _urlManager.CreateNewUrlAsync(input.LongUrl, input.HeaderLink);
            await _urlRepository.CreateAsync(url);
            return new UrlDto() { ID = url.ID, LongUrl = url.LongUrl, ShortUrl = url.ShortUrl };
        }

        public Task UpdateAsync(Guid id, UpdateUrlDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}

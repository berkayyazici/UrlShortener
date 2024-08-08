using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Url;

namespace UrlShortener.Application.Contracts
{
    public interface IUrlRepository
    {
        public List<Url> AllUrls();
        public string GetShortUrl(string longUrl, string headerLink);
        public string GetLongUrl(string shortUrl);
    }
}

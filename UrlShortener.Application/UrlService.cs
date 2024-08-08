using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application;
using UrlShortener.Application.Contracts;
using UrlShortener.Domain.Url;

namespace UrlShortener.Application
{
    public class UrlService : IUrlRepository
    {
        public List<Url> AllUrls()
        {
            List<Url> urls = new List<Url>();   

            Url url1 = new Url()
            {
                ID = Guid.NewGuid(),
                ShortUrl = "https://testURL/22",
                LongUrl = "https://tU/22"
            };


            Url url2 = new Url()
            {
                ID = Guid.NewGuid(),
                ShortUrl = "https://testURL/33",
                LongUrl = "https://tU/33"
            };


            Url url3 = new Url()
            {
                ID = Guid.NewGuid(),
                ShortUrl = "https://testURL/44",
                LongUrl = "https://tU/44"
            };

            urls.Add(url1);
            urls.Add(url2);
            urls.Add(url3);

            return urls;
        }

        public string GetShortUrl(string longUrl, string headerLink)
        {
            throw new NotImplementedException();
        }

        public string GetLongUrl(string shortUrl)
        {
            throw new NotImplementedException();
        }
    }
}

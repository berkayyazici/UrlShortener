using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Application;
using UrlShortener.Application.Contracts;
using UrlShortener.Data.EntityFrameworkCore;
using UrlShortener.Domain.Url;

namespace UrlShortener.Application
{
    public class UrlSqlServerService : IUrlRepository
    {
        private readonly EfContext efContext = new EfContext();
        public List<Url> AllUrls()
        {
            return efContext.Urls.ToList();
        }

        public string GetShortUrl(string longUrl, string headerLink)
        {
            Url url = efContext.Urls.FirstOrDefault(p => p.LongUrl == longUrl);

            if (url is not null)
            {
                return url.ShortUrl;
            }

            List<string> chars = new List<string>();

            chars.AddRange("0,1,2,3,4,5,6,7,8,9".Split(',').ToArray());
            chars.AddRange("A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(',').ToArray());
            chars.AddRange("A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".ToLower().Split(',').ToArray());

            Random random = new Random();

            string shortUrl = string.Empty;
            int urlLength = random.Next(5, 15);

            for (int i = 0; i < urlLength; i++)
            {
                shortUrl += chars[random.Next(1, 52)];
            }

            Url newUrl = new Url()
            {
                ID = Guid.NewGuid(),
                LongUrl = longUrl,
                ShortUrl = headerLink + "/" + shortUrl
            };

            efContext.Urls.Add(newUrl);
            efContext.SaveChanges();

            return newUrl.ShortUrl;

        }

        public string GetLongUrl(string shortUrl)
        {
            Url url = efContext.Urls.FirstOrDefault(p => p.ShortUrl == shortUrl);

            if (url is not null)
            {
                return url.LongUrl;
            }

            return string.Empty;

        }
    }
}

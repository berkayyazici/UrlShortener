using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Url
{
    public class UrlManager
    {
        private readonly IUrlRepository _urlRepository;
        List<string> chars = new List<string>();
        Random random = new Random();

        public UrlManager(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;

            chars.AddRange("0,1,2,3,4,5,6,7,8,9".Split(',').ToArray());
            chars.AddRange("A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(',').ToArray());
            chars.AddRange("A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".ToLower().Split(',').ToArray());
        }

        public async Task<Url> CreateNewUrlAsync([NotNull] string longUrl, [NotNull] string headerLink)
        {
            var existingShortenUrl = await _urlRepository.FindByLongUrlAsync(longUrl);

            if (existingShortenUrl is not null)
            {
                throw new UrlAlreadyExistsException(existingShortenUrl.LongUrl);
            }

            string shortUrl = string.Empty;
            int urlLength = random.Next(5, 15);

            for (int i = 0; i < urlLength; i++)
            {
                shortUrl += chars[random.Next(1, 52)];
            }

            return new Url()
            {
                ID = Guid.NewGuid(),
                LongUrl = longUrl,
                ShortUrl = headerLink + "/" + shortUrl
            };

        }
    }
}

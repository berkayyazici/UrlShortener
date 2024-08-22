using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Shared;

namespace UrlShortener.Domain.Url
{
    public class UrlAlreadyExistsException : Exception
    {
        public UrlAlreadyExistsException(string longUrl)
        {
            new Exception(UrlShortenerDomainErrorCodes.UrlAlreadyExists);
        }
    }
}

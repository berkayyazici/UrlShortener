using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Shared
{
    public static class UrlShortenerDomainErrorCodes
    {
        public const string UrlAlreadyExists = "UrlShortener:00001"; 
        public const string UrlCannotFound = "UrlShortener:00002";
    } 
}

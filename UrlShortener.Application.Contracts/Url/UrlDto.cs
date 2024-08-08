using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.Contracts
{
    public class UrlDto
    {
        public Guid ID { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }

    }
}

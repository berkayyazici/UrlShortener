using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Data.Model
{
    public class Url
    {
        public Guid ID { get; set; }
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }

    }
}

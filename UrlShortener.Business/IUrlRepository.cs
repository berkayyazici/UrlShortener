using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Data.Model;

namespace UrlShortener.Business
{
    public interface IUrlRepository
    {
        public List<Url> AllUrls();
    }
}

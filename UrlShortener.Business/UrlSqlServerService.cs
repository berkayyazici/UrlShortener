using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Data;
using UrlShortener.Data.Model;

namespace UrlShortener.Business
{
    public class UrlSqlServerService : IUrlRepository
    {
        private readonly EfContext efContext = new EfContext();
        public List<Url> AllUrls()
        {
            return efContext.Urls.ToList();
        }
    }
}

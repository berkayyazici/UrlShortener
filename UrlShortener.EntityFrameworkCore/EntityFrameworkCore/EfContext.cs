using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Domain.Url;
using static System.Net.Mime.MediaTypeNames;

namespace UrlShortener.Data.EntityFrameworkCore
{
    public class EfContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }

        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Url>().HasData(new Url
            {
                ID = Guid.NewGuid(),
                ShortUrl = "https://testURL/11",
                LongUrl = "https://tU/11"
            });
        }
    }
}

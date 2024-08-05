using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Data.Model;
using static System.Net.Mime.MediaTypeNames;

namespace UrlShortener.Data
{
    public class EfContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source = MSI\\MSSQLSERVER01; Database = LocalDb; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Url>().HasData(new Url
            {
                ID = Guid.NewGuid(),
                ShortUrl = "https://testURL/11",
                LongUrl = "https://tU/11"
            });
        }
    }
}

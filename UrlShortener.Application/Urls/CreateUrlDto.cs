using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.Urls
{
    public class CreateUrlDto
    {
        [Required]
        public string LongUrl { get; set; }
        [Required]
        public string HeaderLink { get; set; }
    }
}

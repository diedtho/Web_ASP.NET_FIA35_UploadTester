using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_ASP.NET_FIA35_UploadTester.Models
{
    public class Bild
    {
        public IFormFile file { get; set; }

        [Display(Name = "Bemerkungen")]
        public string notices { get; set; }
    }
}

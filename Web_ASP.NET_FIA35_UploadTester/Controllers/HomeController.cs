using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web_ASP.NET_FIA35_UploadTester.Models;

namespace Web_ASP.NET_FIA35_UploadTester.Controllers
{


    public class HomeController : Controller
    {
        List<IFormFile> geposteteBilder = new();
        List<string> allowedMimeTypes = new List<string> { "image/png", "image/jpeg", "image/gif", "image/webp" };

        IWebHostEnvironment config;
        public HomeController(IWebHostEnvironment conf)
        {
            config = conf;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Bild neuBild)
        {
            string wwwPath = this.config.WebRootPath;
            string contentPath = this.config.ContentRootPath;

            // Falls der Ordner "Uploads" noch nicht vorhanden ist, wird er erzeugt
            string path = Path.Combine(this.config.WebRootPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Prüfen, ob MimeType erlaubt ist:
            if (!allowedMimeTypes.Contains(neuBild.file.ContentType))
            {
                // Wenn die Datei nicht vom einem Mime-Typ der erlaubten Typen ist, wird die View erneut leer aufgerufen
                return View();
            }

            // Speichern / Uploaden
            using (FileStream Fstream = new FileStream(wwwPath + "/Uploads/" + neuBild.file.FileName, FileMode.Create))
            {
                neuBild.file.CopyTo(Fstream);
                ViewBag.Dateiname = neuBild.file.FileName;
            }

            return View();
        }
    }
}

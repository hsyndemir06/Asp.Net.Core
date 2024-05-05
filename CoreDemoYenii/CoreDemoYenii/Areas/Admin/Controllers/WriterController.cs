using CoreDemoYenii.Areas.Admin.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemoYenii.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //tüm listeyi getiryor burası

        public IActionResult WriterList()
        {
            var JsonWriters = JsonConvert.SerializeObject(writers);
            return Json(JsonWriters);
        }


        //burası da aşağıdaki dışarıdan girilen id ile getiriyor
        public IActionResult GetWriterByID(int writerID)
        {
            var findWriter = writers.FirstOrDefault(x => x.WriterID == writerID);
            var JsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(JsonWriters);
        }


        // burası da ekleme kısmı

        public IActionResult AddWriter(WriterClass w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }

        // silme islemi
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.WriterID == id);
            writers.Remove(writer);
            return Json(writer);
        }


        // güncelleme islemi
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.WriterID == w.WriterID);
            writer.WriterName = w.WriterName;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                WriterID= 1,
                WriterName="Ahmet"
            },
            new WriterClass
            {
                WriterID=2,
                WriterName="Canan"
            },
            new WriterClass
            {
                WriterID =3,
                WriterName="hsyn"
            }
        };

    }
}

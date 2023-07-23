
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class ResimController : Controller
    {
        // GET: Resim
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ResimEkle(HttpPostedFileBase imageFile)
        {
            try
            {
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(imageFile.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(imageFile.ContentLength);
                    }

                    var resim = new TBLRESIM
                    {
                        ResimData = imageData
                    };

                    db.TBLRESIM.Add(resim);
                    db.SaveChanges();

                    return Json(new { success = true, message = "Resim başarıyla kaydedildi." });
                }
                else
                {
                    return Json(new { success = false, message = "Lütfen bir resim seçin." });
                }
            }
            catch (Exception ex)
            {
                // Hatanın detaylarını loglamak için:
                // Loglama kütüphanesini kullanarak hatayı loglayabilirsiniz.

                // Hatanın detaylarını konsola yazdırmak için:
                Console.WriteLine("Hata Mesajı: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);

                return Json(new { success = false, message = "Resim kaydedilirken bir hata oluştu: " + ex.Message });
            }
        }

    }
}
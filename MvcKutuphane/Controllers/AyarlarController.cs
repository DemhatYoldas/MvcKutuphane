using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class AyarlarController : Controller
    {
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();   
        // GET: Ayarlar
        public ActionResult Index()
        {
            var kullanicilar=db.TBLADMİN.ToList();
            return View(kullanicilar);
        }

        [HttpGet]
        public ActionResult YeniAdmin() 
        { 
            return View(); 
        }

        [HttpPost]
        public ActionResult YeniAdmin(TBLADMİN t)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            var varsayilan = "/Images/Admin/white.jpg";
            t.Fotograf = varsayilan;
            db.TBLADMİN.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            var admin = db.TBLADMİN.Find(id);
            admin.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AdminGetir(int id)
        {
            var getir = db.TBLADMİN.Find(id);
            return View("AdminGetir", getir);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminGuncelle(TBLADMİN tBLADMİN, HttpPostedFileBase Fotograf)
        {
            if (ModelState.IsValid)
            {
                // Mevcut fotoğraf yolu
                string mevcutFotografYolu = tBLADMİN.Fotograf;

                // Yeni bir resim yüklenip yüklenmediğini kontrol edin
                if (Fotograf != null && Fotograf.ContentLength > 0)
                {
                    // Eski resmi silin (isteğe bağlı)
                    if (!string.IsNullOrEmpty(mevcutFotografYolu))
                    {
                        var oldImagePath = Server.MapPath(mevcutFotografYolu);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Yeni resmi kaydedin
                    var imageFileName = Path.GetFileName(Fotograf.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Admin"), imageFileName);
                    Fotograf.SaveAs(path);

                    tBLADMİN.Fotograf = "/Images/Admin/" + imageFileName;
                }
                else
                {
                    // Eğer yeni bir resim yüklenmediyse, mevcut fotoğraf yolu kullanılır
                    tBLADMİN.Fotograf = mevcutFotografYolu;
                }

                // Diğer özellikleri güncelleyin ve değişiklikleri kaydedin
                db.Entry(tBLADMİN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBLADMİN);
        }

    }
}
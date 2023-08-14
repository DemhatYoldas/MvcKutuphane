using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
   
    public class PanelimController : BaseController
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Panelim
        [HttpGet]
        public ActionResult Anasayfa()
        {
            return View();
        }

        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            var d1 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(z => z.AD).FirstOrDefault();
            ViewBag.d1 = d1;
            var d2 = db.TBLUYELER.Where(x => x.MAIL == uyemail).Select(z => z.FOTOGRAF).FirstOrDefault();
            ViewBag.d2 = d2;
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(TBLUYELER p, HttpPostedFileBase FOTOGRAF)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var kullanici = (string)Session["Mail"];
                    var uye = db.TBLUYELER.FirstOrDefault(x => x.MAIL == kullanici);

                    uye.AD = p.AD;
                    uye.SOYADI = p.SOYADI;
                    uye.KULLANICIADI = p.KULLANICIADI;
                    uye.SIFRE = p.SIFRE;
                    uye.TELEFON = p.TELEFON;
                    uye.OKUL = p.OKUL;

                    // Yeni bir resim yüklenip yüklenmediğini kontrol edin
                    if (FOTOGRAF != null && FOTOGRAF.ContentLength > 0)
                    {
                        // Eski resmi silin (isteğe bağlı)
                        if (!string.IsNullOrEmpty(uye.FOTOGRAF))
                        {
                            var oldImagePath = Server.MapPath(uye.FOTOGRAF);
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        // Yeni resmi kaydedin
                        var imageFileName = Path.GetFileName(FOTOGRAF.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/Profil"), imageFileName);
                        FOTOGRAF.SaveAs(path);

                        uye.FOTOGRAF = "/Images/Profil/" + imageFileName;
                    }

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Profil güncelleme sırasında bir hata oluştu: " + ex.Message;
                    return View("Index", p);
                }
            }

            // Hata durumunda sayfayı aynı şekilde gösterin
            return View("Index", p);
        }

        public ActionResult Kitaplarım()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLUYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }

        public ActionResult Duyurular()
        {
            var duyuru = db.TBLDUYURULAR.Where(z => z.Durum == true).ToList();
            return View(duyuru);
        }

        public PartialViewResult partial1()
        {
            return PartialView();
        }

        public PartialViewResult partial2()
        {
            return PartialView();
        }
    }
}
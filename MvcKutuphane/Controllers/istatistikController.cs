using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerkitap = db.TBLKITAP.Count();
            ViewBag.dgr1 = degerkitap;

            var degeruyesayi = db.TBLUYELER.Count();
            ViewBag.dgr2 = degeruyesayi;

            var degerkasatutar = db.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.dgr3 = degerkasatutar;

            var degerodunckitap = db.TBLKITAP.Where(x => x.DURUM == false).Count();
            ViewBag.dgr4 = degerodunckitap;

            var degerkategori = db.TBLKATEGORI.Count();
            ViewBag.dgr5 = degerkategori;

            var degerenaktif = db.TBLHAREKET.Where(x => x.UYE == x.KITAP);
            ViewBag.dgr6 = degerenaktif;

            var degerenaktifuye = db.EnAktifUye().FirstOrDefault();
            ViewBag.dgr7 = degerenaktifuye;

            var degerenfazlakitapyazarı = db.EnFazlaKitapYazar().FirstOrDefault();
            ViewBag.dgr8 = degerenfazlakitapyazarı;

            var degereniyiyayınevi = db.TBLKITAP
               .GroupBy(x => x.YAYINEVI)
               .OrderByDescending(z => z.Count())
               .Select(y => y.Key)
               .FirstOrDefault();

            ViewBag.dgr9 = degereniyiyayınevi;

            var degerencokokunankitap = db.EnCokOkunanKitap().FirstOrDefault();
            ViewBag.dgr10 = degerencokokunankitap;

            var degermesaj = db.TBLILETISIM.Count();
            ViewBag.dgr11 = degermesaj;

            var degerenbasarilipersonel = db.EnBasariliPersonel().FirstOrDefault();
            ViewBag.dgr12 = degerenbasarilipersonel;


            var today = DateTime.Today;

            var bugunOduncAlinanKitaplar = db.TBLHAREKET
                .Where(hareket => hareket.ALISTARIH.HasValue)
                .ToList()
                .Where(hareket => hareket.ALISTARIH.Value.Date == today)
                .Join(
                    db.TBLKITAP,
                    hareket => hareket.KITAP,
                    kitap => kitap.ID,
                    (hareket, kitap) => kitap.AD
                )
                .Distinct()
                .FirstOrDefault();

            ViewBag.dgr13 = bugunOduncAlinanKitaplar;

            return View();
        }

    }
}
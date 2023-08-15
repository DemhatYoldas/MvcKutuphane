using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class BaseController : Controller
    {
        // bu ksımda her sayfa da fotograf ve kullanıcı adını almak için basecontroller oluşturduk ama bunu dezavantajı veri erişimi sıklığına neden olabiliyor bunun  için çözüm bulana kadar boyle :)
        DBKUTUPHANEEntities db =new DBKUTUPHANEEntities();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Mail"] != null)
            {
                var uyemail = (string)Session["Mail"];
                var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);

                if (degerler != null)
                {
                    var ad = degerler.AD;
                    var foto = degerler.FOTOGRAF;

                    ViewBag.KullaniciAdi = ad;
                    ViewBag.KullaniciFotografi = foto;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
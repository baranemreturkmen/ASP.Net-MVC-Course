using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course.Controllers
{
    public class Home9Controller : Controller
    {
        private List<string> list = new List<string>() { "Baran", "Emre", "Türkmen" };

        //Jquery.Get -> $.get() -> Javascript frameworklerinden jquery kullanarak ajax işlemleri yapılacak.
        //Ajax Helper metodları yerine bazen adım adım jquery işlemlerini kodlamamız gerekiyor bu tarz durumlarda kullanıyoruz.
        //Get metodu ile get isteklerinde bulunabiliriz. Hazır metod. Bir adresteki herhangi bir action'ı çağırmamızı sağlıyor.
        //Action sonucunda aldığı veriyi bize geri döndürüyor ve kullanmamızı sağlıyor.
        public ActionResult Bills()
        {
            return View();
        }

        //Jquery.Get ile veri gönderme
        public ActionResult Medicines()
        {
            return View();
        }

        public PartialViewResult GetDatas(string data="")
        {
            if(string.IsNullOrEmpty(data)==false)
            {
                list.Add(data);
            }

            //Veri tabanından veriler çekiliyormuş gibi düşün burada :)
            System.Threading.Thread.Sleep(3000);

            return PartialView("_DataItemPartialView",list);
        }

        //Jquery.Get ile veri gönderme
        //public PartialViewResult GetDatas(string data)
        //{
        //    list.Add(data);

        //    //Yada default atama yapıp burada yapacağımı yukarıda ki var olan metodda da yapabilirim.

        //    //Veri tabanından veriler çekiliyormuş gibi düşün burada :)
        //    System.Threading.Thread.Sleep(3000);

        //    return PartialView("_DataItemPartialView", list);
        //}


        //$.load -> get metodunda ki gibi bir url alıyor, ve aldığı url bilgisi sonucunda dönen veriyi o anda hangi elementin
        //sonunda çağırdıysanız load metodunu o elementin içine atıyor. get metodunda veri gelince o elementin html kısmını at tarafını yazmayabiliyoruz 1-2 satır kısalıyor.
        //Herhangi bir element yakalayıp o elementin sonunda bu metodu çağırıyoruz. Veridğimiz Url sonucundan aldığı veriyi burada yazdığımız elementin içine,html'in otomatik yazıyor kendisi.
        public ActionResult Books()
        {

            return View();
        }

        //$.load -> Jquery load ile veri gönderme
        public ActionResult Shelves()
        {

            return View();
        }

        //$.ajax -> Aslında get ve load gibi metodları kullanmama gerek kalmıyor JqueryAjax ile tercih meselesi ama tabiki.
        //Bu metod hepsini kapsayan genel bir metod yine diğerlerinin yaptığı işi yapabiliyoruz.
        public ActionResult Notes()
        {

            return View();
        }

        public ActionResult Pencils()
        {
            return View();
        }

        //Sunucudan (koddan) her zaman partial view döndürmüyoruz. PartialView hızlı bir şekilde html oluşturuyor ama bu html
        //oluşturma yükü sunucuya yüklenmiş oluyor. Bazen verilerin yüklü olması ve işlemlerin sıklığı sebebiyle daha performanslı
        //çalışabilmesi için html üretiminin client'a yani istekte bulunan bilgisayara yıkılması, onun üzerinde yapılması
        //veya karşı tarafa html göndermeme durumları olabilir eğer karşı taraf bir mobil uygulama ise eğer html yerine 
        //json data gönderebiliriz vs. vs.
        //Burada html oluşumunu cilent üzerine yıkacağız. 
        public ActionResult Erasers()
        {
            return View();
        }

        public JsonResult GetDatas2(string data = "")
        {
            if (string.IsNullOrEmpty(data) == false)
            {
                list.Add(data);
            }

            //Veri tabanından veriler çekiliyormuş gibi düşün burada :)
            System.Threading.Thread.Sleep(3000);

            //AllowGet ile ben bir datayı json'ı bilinçli olarak dışarıya açtığımı söylüyorum. Bu ifadeyi vermezsem eğer get talebi ile bu action'ın sonucunu alamam. 
            //Parametre olarak obje alıyor dilediğin nesne verip Json olarak geri döndürebilirsin.
            return Json(list,JsonRequestBehavior.AllowGet);
        }
    }
}
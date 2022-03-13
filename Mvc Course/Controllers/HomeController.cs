using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course.Controllers
{
    public class HomeController : Controller
    {
        // HomeController : Controller -> LocalHost/Home/HomePage
        //Home -> Controller Class, istekler buraya geliyor ilk olarak.
        //HomePage -> Action Method, görünümü dönecek.
        //View'da görünüm ile alakalı kodları yazıyoruz. Controllerda C# kodlarımız yer alıyor.
        //GET : Home -> Sayfayı Görünümü Çağırıyorum. [HttpGet] diye attributeda ekleyebilirsin ama hiçbir attribute ekli değilse
        //default olarak get işlemini gerçekleştirecektir.
        //POST : [HttpPost] -> Sayfadan data alıyorum.
        //div>ul>li>p>{yazı] -> Emmet (Zen-Coding) örneği
        //div.style1
        //div#mydiv
        //ul>li.item*5
        //ul>li.item$*5
        //ul>li.item$$*5
        //div>lorem12
        //a.lorem2
        //a[href="" class = "btn btn-success"]>lorem2
        //a[href="url" class = "btn btn-success"]>lorem2
        //ul>li>p>lorem3^^^hr -> ben de bu çalışmadı.
        //(ul>li>p>lorem3)+hr -> bu da çalışmadı.
        //paranteze al hepsini. ((ul>li>p>lorem3)+hr) ve (ul>li>p>lorem3^^^hr) böyle çalışacaktır.
        //((ul>li>p>lorem3)+(ul>li>a>lorem1)+hr+br)
        // > : elementin alt elementini oluşturma
        // + : aynı seviye elementler
        // # : id
        // * : tekrar
        // [] : attribute
        // {} : metin
        // ^ : bir üst seviye elemente ulaşıyoruz.
        //html:5 -> hızlıca html head ve body'si oluşturuyor.
        //emmet documentation or emmet cheatsheat
        //Razor syntax'ı html içerisinde C# kodlarını kullanmak istediğimde kullandınğım bir syntax
        public ActionResult HomePage()
        {
            return View();
        }

        //Emmet Zen Code örnekleri var burada.
        public ActionResult Categories()
        {
            return View();
        }

        //Razor syntax örnekleri var.
        public ActionResult Products()
        {
            return View();
        }

        //Razor syntax örnekleri var.
        public ActionResult Persons()
        {
            return View();
        }

        //Html helpers
        public ActionResult Sales()
        {
            return View();
        }

        //Custom Html Helpers
        public ActionResult Managers()
        {
            return View();
        }

        //Url helpers
        public ActionResult Accounts()
        {
            return View();
        }

        //Httputitlity -> Url ile Htmlhelpers'ın birleşimi gibi düşün ama hepsini içermiyor.
        public ActionResult Customers()
        {
            return View();
        }

        //View ve Layout kullanımı
        public ActionResult About()
        {
            return View();
        }

        //View ve Layout kullanımı
        public ActionResult Contact()
        {
            return View();
        }
    }
}
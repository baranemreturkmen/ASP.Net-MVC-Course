using Mvc_Course.Models;
using Mvc_Course.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course.Controllers
{
    public class Home5Controller : Controller
    {
        //Controllerdan View'a veri gönderme
        public ActionResult Adverts()
        {
            //ViewData["text1"] = "Emre Türkmen";
            //ViewData["check1"] = true;
            //ViewData["text1"] = "abc"; ViewData sözlük yapısında bir alan olduğı için aynı anahtar değere sahip 2.bir yapı
            //1. yapının üzerine yazılmış oluyor.
            //[] parantezlerle uğraşmak yorucu olduğu için ViewBag yapısı getirilmiş. ViewBag yapısı dynamic bir nesne aslında.
            //Dynamic nesnelerde derleme zamanı var olan hatalar belli olmaz intellisense çok yardımcı olmaz .'ya bastığınızda vs.
            //ve ortaya çıkan hatalar yazım hataları mantık hataları vs. run time'da belli olur. Aynı python,javascript gibi ki
            //zaten oralardaki nesneler de dinamikti yani mantık oradaki yapı ile aynı aslında.

            //ViewBag.text1 = "Emre Türkmen";
            //sanki benim bir Viewbag class'ım var ve .text1 dediğimde arkada dinamik olarak çat diye alan oluşturuluyor bu 
            //şekilde düşünebilirsin dinamiklikten kast edilen buydu.
            //ViewBag.check1 = true;

            TempData["text1"] = "Emre Türkmen";
            TempData["check1"] = true;

            //ViewBag ViewData ile kıyaslandığı zaman yazım kolaylığı sağlıyor. TempData sayfadan bir linke tıkladın bir sonraki
            //sayfanın Action'ınana geçtin. TempData ile oluşturulan veriler o sonraki Action içinde bellekte tutuluyor erişilebilir oluyor
            //Ama o linkten başka bir linke geçtin diyelim. 2. action için tutulmaz.

            //Burada bu 3 yöntemden birini kullandın. View  dosyasında buradan kullandığın yöntemi değilde kalan 2 yöntemden biri
            //ile burada ki veriyi çağırdığında kodlar hata vermeyecektir. EDIT Controller ViewBag iken View TempData'daydı
            //Controllerda ki veri ön yüze yansımadı.

            return View();
        }

        //Controllerden View'a veri gönderme HtmlHelper kullanma
        public ActionResult Notifications()
        {
            ViewBag.text1 = "Emre Türkmen";
            ViewBag.check1 = true;

            ViewBag.list1 = new SelectListItem[]
            {
                new SelectListItem(){Text = "Baran"},
                new SelectListItem(){Text="Emre"},
                new SelectListItem(){Text = "Türkmen"}
            };

            TempData["t1"] = ViewBag.text1;
            TempData["c1"] = ViewBag.check1;

            return View();
        }

        //TempData'da anlatılan sonraki sayfada da bellekte veri taşınması olayını inceledik.
        public ActionResult Managers()
        {   
            //Bir önceki actiona ait veriler Mvc'de taşınıyor farkat bunun bir önceki actiondaki veriyi atamam gerek 
            //taşınacak action'a.

            ViewBag.text1 = TempData["t1"];
            ViewBag.check1 = TempData["c1"];

            return View();
        }

        //TempData'da anlatılan sonraki sayfada da bellekte veri taşınması olayını inceledik. 2. sayfaya veri taşınmayacak.
        public ActionResult Gamers()
        {
            ViewBag.text1 = TempData["t1"];
            ViewBag.check1 = TempData["c1"];

            return View();
        }

        //View'dan Controller'a veri gönderme Post işlemi
        //Şimdi sayfadan veri alıyorum ama sonuçta veri alacağım sayfayı görmem ve o sayfada bir takım işlemler yapmam lazım.
        //Bundan dolayı öncesinde o sayfaya ulaşabilmek adına bir HttpGet işlemi o sayfayı görmem lazım ki zaten hep bu şekilde
        //Controller ile çalıştık default olarak controllerlar getdeydi.
        public ActionResult Additions()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Additions(string text1,bool check1,string list1)
        {
            //Parametrede ki isimler ve veri tipler View dosyasında ki post ile burada görmek istediğim datalarınki ile aynı olmalı.

            //Parametre dışında Request objesi yardımıyla da ben post işleminden dönen datalarımı tutabilirim.
            //Request objesine bağlı koleksiyonlara Viewda almak istediğim elementlerin doğru değerlerini girmem önemli

            var t1 = Request.Form["text1"];
            var l1 = Request.Form["list1"];
            var c1 = Request.Form.GetValues("check1")[0];

            //Yukarıdaki durum boolean değerlere özel bir durum!

            return View();
        }

        //Model kavramı ve Model Binding
        //Model klasörü bizim verilerimizi taşıyan nesneleri içeren bir klasördür.Hem veritabanından çektiğimiz nesne hemde sayfaya 
        //View'a giden nesneleri bu model klasörü içerisinde oluştururuz ki yeri belli olsun. View sayfalarla, Controller yönetimle,
        //Model nesneleri, verileri tutan sınıflarla alakalı.
        public ActionResult Prices()
        {
            Person person = new Person();
            person.Name = "Emre";
            person.Surname = "Türkmen";
            person.Age = 25;

            //Bu bilgileri sayfaya aşağıdaki View metodu aracılığıyla aktaracağım.

            return View(person);
        }

        //Model tipindeki nesneyi nasıl alırım frontend tarafından?
        [HttpPost]
        public ActionResult Prices(Person p)
        {

            return View(p);
            //Yukarıda ki kullanım ile Post ile gelen yeni verileri, verileri aldığım sayfaya aynen yolluyorum.
        }

        //Şimdi benim bir sayfam 2 tane nesneye ait Modeli classı kendi içerisinde kullanmak zorunda olabilir fakat bir sayfa
        //bir view dosyası yalnızca bir tane model alabilir. Bu durumda ihtiyaç neyse bu 2 modeli birleştirip ayrı bir model 
        //oluşturmam gerek bu durumda ViewModels diye bir klaösür oluşturup 2 nesne için kullanmam gereken alanları tek bir nesne
        //altında toplayıp bu klasör altında oluşturuyorum. Hatta ViewModels altında da Home,Applications,Shared vs. tarzında bir
        //kategorize mantığı olmalı proje büyüdüğü zaman işler karışmasın vs. diye. Eğer 2 nesnenin birleşiminden ziyade veritabanına ait nesneler varsa onları models klasörünün altında tut.
        public ActionResult Applications()
        {
            Person person = new Person();
            person.Name = "Enes Malik";
            person.Surname = "Türkmen";
            person.Age = 16;

            Address address = new Address();
            address.AddressDescription = "Beytepe";
            address.City = "Ankara";
            //ctrl + . ile using seçeneklerini hemen açabilirsin.

            ApplicationsPageViewModel applicationsPageViewModel = new ApplicationsPageViewModel();
            applicationsPageViewModel.Student = person;
            applicationsPageViewModel.HomeAddress = address;

            return View(applicationsPageViewModel);
        }
    }
}
using Mvc_Course.Models;
using Mvc_Course.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course.Controllers
{
    public class Home7Controller : Controller
    {
        //ViewBag ile DropDownList doldurma  ve değer alma
        public ActionResult Exams()
        {

            ViewBag.SelectedCityId = -1;
            ViewBag.SelectedCountryId = -1;

            //Yukarıdaki değerleri bu sayfada Post işleminden sonra kullanacağım için şuanki Get işleminde boş oldukarından
            //-1 atadım. Hiç tanımlamasaydım da olurdu. Tanımlamak zorunda değilim.

            //Dropdown'a veri gönderirken SelectList yada List<SelectListItem> şeklinde veri yollamalıyım.

            SelectList selectListCity = new SelectList(City.GetFakeCities(),"CityId","CityName");
            SelectList selectListCountry = new SelectList(Country.GetFakeCountries(),"CountryId","CountryName");

            //Şimdi şöyle bir durum var. Bu metod özelinde Get ve Post işleminde DropDownList'i doldurmak için sürekli verileri
            //getiriyoruz. Fake data yerine gerçek verilerle çalıştığımızı düşünelim. Bu durumda sürekli db'ye gitmemiz gerekecekti.
            //Eğer çok sık güncellenmeyen verilerle uğraşıyorsanız, bu tarz verileri devamlı database'den çekmek yerine cache mekanizmasınıı
            //kullanıp databaseden verileri bir kere çekip cache'e atıp sonrasında geçici tampon bölge denilen cache bölgesinden 
            //sürekli veriyi alıp sayfaya gönderirsek hem uygulama daha hızlı çalışır hem de database'i yormamış oluruz database
            //kendi işleriyle uğraşır. Veri güncellendiğinde değiştiğinde cache'i yenilemek gerekiyor.

            ViewBag.CitiesData = selectListCity;
            ViewBag.CountriesData = selectListCountry;

            return View();
        }

        [HttpPost]
        public ActionResult Exams(int SelectedCityId,int SelectedCountryId)
        {
            //Buradaki yapı şu. Get ile sayfa ön tarafa yükleniyor. İstek atıyoruz. Post ile sayfadan veri alıyoruz.
            //Post ile sayfadan veri aldığım an aynı sayfa üzerinde çalışıyorum. Ne olacak bu durumda. İlk get durumu oluştuğunda
            //sayfa geldiğinde submit butununa bastığım an post işlemi aktif olacak ve tekrar aynı sayfa yüklenecek.
            //Bu durumda post işlemi gerçekleşip sayfa yenilendiğinde yukarıda get ile oluşturduğum ViewBag yapısı uçtu. Aynı sayfadayım
            //fakat sayfa yenilendi. Bu durumda yukarıda oluşturduğum ViewBagleri tekrar burada kullanacaksam oluşturmam lazım.
            //Eğer TempData kullansaydık TempData ile elimizdeki verilerle bir adım ileri gitme hakkımız vardı bundan dolayı
            //burada tekrar tanımlama işine girmeyecektik. DropDownların terkar içlerinin dolmasını istediğimden Get metodu içerisindeki ViewBagleri tekrar oluşturuyorum.

            SelectList selectListCity = new SelectList(City.GetFakeCities(), "CityId", "CityName");
            SelectList selectListCountry = new SelectList(Country.GetFakeCountries(), "CountryId", "CountryName");

            ViewBag.CitiesData = selectListCity;
            ViewBag.CountriesData = selectListCountry;

            //Post işlemi sonucu gelen değerleri dolduruyorum. Bu değerleri aynı sayfada kullanacağım.

            ViewBag.SelectedCityId = SelectedCityId;
            ViewBag.SelectedCountryId = SelectedCountryId;

            return View();
        }

        //Model ile DropDownList doldurma  ve değer alma.
        //Database nesneleri Models klasöründe, database nesnelerine ait ortak nesneler ViewModels klasöründe
        //bu yapıya mvvc-> model view viewmodels controllers yapısı deniyor.
        public ActionResult Examples()
        {
            ExamplesPageViewModel examplesPageViewModel = new ExamplesPageViewModel()
            {
                CitiesData = new SelectList(City.GetFakeCities(), "CityId", "CityName"),
                CountriesData = new SelectList(Country.GetFakeCountries(), "CountryId", "CountryName"),
                SelectedCityId = -1,
                SelectedCountryId = -1
            };

            //Burada get controllerında SelectedCityId ve SelectedCountryId yerine başka değerler girseydim FakeData içerisinde
            //var olan değerler arasından bu durumda o değerlere ait datalar sayfa açılır açılmaz gelecekti. -1 FakeData içerisinde
            //olmayan bir değer olduğu için bu tarz durumlar için DropDownList içerisinde ayarlanan default mesaj DropDownListte gözükecektir.

            return View(examplesPageViewModel);
        }

        [HttpPost]
        public ActionResult Examples(ExamplesPageViewModel examplesPageViewModel)
        {
            //Yukarıda CitiesData ve CountriesData değerlerini doldurdum. Fakat burada bir daha doldurmam lazım çünkü
            //metod içerisinde oluşturduğum class'ın propertylerini yukarıda ki metodda doldurdum aslında ve metodlarda
            //oluşturulan değişkenler yerel değişkenlerdir o metoddan çıktığınız zaman o metoddaki değişkenler bellekte
            //tutulmazlar. Yukarıdaki metod get işlemi yapacak sayfayı yükleyecek sonrasında ise post işlemi çalıştığında 
            //yukarıda ki metodla olan işimiz bitecek.

            //Yukarıdaki metodda ki SelectedCityId ve SelectedCountryId propertylerini doldurmaya gerek yok çünkü bu değerleri 
            //ben view dosyamda DropDownList sayesinde alacağım.

            examplesPageViewModel.CitiesData = new SelectList(City.GetFakeCities(), "CityId", "CityName");
            examplesPageViewModel.CountriesData = new SelectList(Country.GetFakeCountries(), "CountryId", "CountryName");

            //Aynı sayfayı post işlemi sonrasında tekrar çalıştırmak istediğim için eksik olan dataları yukarıda bir daha doldurdum.

            //Soru: Post işleminden sonra farklı sayfaya gidebilir miyim???

            return View(examplesPageViewModel);
        }

        //Model ve JQuery ile Cascade DropDownList Doldurma ve Değer Alma
        //Cascade -> Bir DropDownListte seçim işlemi yapıp diğer DropDownListte otomatik doldurma işlemi.
        public ActionResult Grades()
        {

            ExamplesPageViewModel examplesPageViewModel = new ExamplesPageViewModel()
            {
                CitiesData = new SelectList(City.GetFakeCities(), "CityId", "CityName"),
                CountriesData = new SelectList(Country.GetFakeCountries(), "CountryId", "CountryName"),
                SelectedCityId = -1,
                SelectedCountryId = -1
            };

            return View(examplesPageViewModel);
        }

        [HttpPost]
        public ActionResult Grades(ExamplesPageViewModel examplesPageViewModel)
        {
            examplesPageViewModel.CitiesData = new SelectList(City.GetFakeCities(), "CityId", "CityName");
            examplesPageViewModel.CountriesData = new SelectList(Country.GetFakeCountries(), "CountryId", "CountryName");

            return View(examplesPageViewModel);
        }

        public JsonResult GetCitiesByCountry(int id)
        {
            //Metoda geçilen parametre adını id olarak verin çünkü ControllerAdı/ActionAdı/3. parmetre her zaman id ismiyle okunur
            //Tipi önemli değil ama id kelimesi önemli, id kelimesi ile tanımlı. Proje içerisinde App_Start altında routes configde id olarak tanımlı. id ismini değiştirirsem eğer parametre adını değişterebilirim.

            int countryId = id;

            List<City> result = City.GetFakeCities().Where(x => x.CountryId == countryId).ToList();

            return Json(result,JsonRequestBehavior.AllowGet);
            //Bu actionı get metodu ile oluşturmuştuk. Ki ajax isteği gerçekleştirirken de isteğimizin get türünde olduğunu belirtmiştik. Ama MVC güvenlik amacıyla actionı get işlemlerine kapatıyor ve datayı vermiyor. Bundan dolayı 2. parametreyi girdik. Bu şekilde bu metodu Get'e açmış olduk. Metod JSON formatında veri dönecek. Burada dönen data view içerisinde ajax işleminin başarılı olması durumunda done metodu içerisine yazdığım result içerisine gelecek.
        }
    }
}
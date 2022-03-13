using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course.Controllers
{
    public class Home4Controller : Controller
    {
        //Nested Layout ve Section kullanımı
        //Sorun şu buradaki, iç içe layout kullanımı ile birlikte iç içe nested section kullanımı nasıl yaparız.
        //Temel bir layout olacak sadece header tasarımıı içerecek, header her sayfada çıkacak. Bu layoutu başka layoutlarda 
        //kullanacak ve iç içe layoutlar oluşacak. 
        //PointsLayoutPage -> Headerı içerecek.
        //CreditCardsLayoutPage -> Header altında kalan alanın sol tarafını içerecek.
        //PaymentsLayoutPage -> Header altında kalan alanın sağ tarafını içerecek.
        //PaymentsLayoutPage ve CreditCardsLayoutPage header içeriyor. 2si için PointsLayoutPage ortak.
        //PaymentsLayoutPage ve PointsLayoutPage, PointsLayoutPage'den türeyecek.
        //PROBLEM ŞU-> PointsLayoutPagede bir section var, section points. Bir tane Debts sayfası oluşturulacak.
        //Debts ya PaymentsLayoutPage yada CreditCardsLayoutPage ile çalışacak. Dolayısıyla doğrudan PointsLayoutPage 
        //ile çalışmayacak. PaymentsLayoutPage kulanacak mesela, PaymentsLayoutPage'da PointsLayoutPage kullandığı için 
        //bütün hepsi birleşip bütün bir html ortaya çıkaracaklar. Fakat bu durumda Debts sayfasından PointsLayoutPagedeki
        //sectiona nasıl kod gönderecem. Sonuçta PointsLayoutPage'i kullanan PaymentsLayoutPage'i kullanacak Debts sayfası.

        //Şöyle bir hata gelecek ->The following sections have been defined but have not been rendered for the layout page "~/Views/Shared/_CreditCardsLayoutPage.cshtml": "Section1". 

        //CreditCardsLayoutPage aradaki köprüyü sağlamalı. İç içe rendering yapmalısın.
        public ActionResult Points()
        {
            return View();
        }

        //Nested Layout ve Section Kullanımı
        public ActionResult Debts()
        {
            return View();
        }

        //.row>.col-md+.col-md-8
        //ul>li*5>a[href =#]>lorem3
        //>lorem12

        //Partial View -> İçerisine yazdığım kodları istediğim yerde çağırıp kullanabiliyorum. Bunu layout yapısı ile de
        //sağlayabiliyordum fakat partial view ile içerisindeki yapıyı tek seferde yapıp aynı sayfada birden çok kez yada farklı
        //sayfalarda kullanabilirim.  Layout yapısında mesela bir yapı ana sayfada kullandın. Aynı sayfanın footerında da 
        //kullanmak isiyorsun. Kodu gidip oraya kopyalaman lazım. Yada başka sayfada farklı kullanmam gereken bir yapı var
        //sayfalar farklı yapıda ama farklı yapıda ki sayfanın layoutundaki bir yapıyı başka bir sayfada kullanman gerekiyor vs.
        //ayrı ayrı bu tarz durumlar için hep layout oluşturmaktansa partial viewda bu tekrar eden yapıları yazıp sayfada çağırmak en iyisi. O zaman şunu söylemek lazım tekrar eden, farklı yerlerde kullanmayı düşündüğün yapılar için partial
        //view, benzer yapıdaki sayfalar için ana bir iskelet oluşturmak amacıyla layout kullanabilirsin.
        public ActionResult Raises()
        {
            return View();
        }

        public ActionResult Salaries()
        {
            return View();
        }

        //ul>li*3>a[href=#]>lorem3
    }
}
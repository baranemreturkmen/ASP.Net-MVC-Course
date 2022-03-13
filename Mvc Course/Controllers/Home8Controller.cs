using Mvc_Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Course.Controllers
{
    public class Home8Controller : Controller
    {
        //Ajax -> asynchronous javascript and xml
        //Sayfalar yenilenmeden tekrar sunucuya gidip yeni baştan yüklenmeden sadece istenilen kısmın gönderilip istenilen miktarda 
        //datanın alındığı yapılar sağlanmış oluyor. -> Performans, sayfa yenilenmiyor kullanıcı dostu.
        //ASP.NET MVC ile gelen AjaxHelper Metodlar javascript kodları ile uğraşmadan ajax ile uğraşmamıza imkan veriyor, büyük kolaylık sağlıyor.
        //Ajax kodlarını Jquery ile yazabiliyoruz fakat jquery'nin genel olarak kullandığım Layout dosyasının içerisinde yüklenmiş olması ASP.NET MVC ile gelen ajax helper metodlarının kullanılmasına imkan sağlamıyor. Bunun için paket yüklemem nuget üzerinden.
        //Paket ismi -> Microsoft.jQuery.Unobtrusive.Ajax
        public ActionResult Inventories()
        {
            List<string> datas = new List<string>() { "Baran", "Emre", "Türkmen" };
            Session["mylist"] = datas;

            return View();
        }

        public PartialViewResult LoadData()
        {
            //List<string> datas = new List<string>() { "Baran", "Emre", "Türkmen" };
            //Listeyi index içerisinde Sesssion ile tutmaya karar verdi.Session'ı partialview'a yolluyorum.

            System.Threading.Thread.Sleep(3000);
            //Çok hızlı çalıştığı için yükleniyor yazısını görebilmek için 3 saniye datayı geciktiriyorum.

            return PartialView("_DataListPartialView",Session["mylist"] as List<string>);
        }

        public MvcHtmlString RemoveData(int id)
        {
            List<string> datas = Session["mylist"] as List<string>;
            datas.RemoveAt(id);

            Session["mylist"] = datas;
            //Session'ı güncellemen lazım çünkü liste değişti!

            System.Threading.Thread.Sleep(3000);

            return MvcHtmlString.Empty;
            //geriye boş string döndürmesini istiyorum! Buradan dönen boş string aslında sil butununa bastıktan sonra li elementine giden boş string bu şekilde metni silmiş oluyorum!

            //Bu haliyle index üzerinden silme işlemi yaparsam hata verecektir. Çünkü liste içersinde index sürekli değişir. QA'da ki gibi item üzerinden ilerle -> BURAYI DEĞİŞTİR!
        }

        //Ajax - BeginForm Method - 1
        public ActionResult Calendar()
        {
            //Sayfada session var ama session dolu olmasına rağmen sayfa yenilenince veriler kayboluyor bunu engellemek için 

            List<TodoItem> list = null;

            if (Session["todolist"] != null)
            {
                list = Session["todolist"] as List<TodoItem>;
            }

            else
            {
                list = new List<TodoItem>();
            }

            //listeyi model olarak gönderemem sayfayı o şekilde tasarlamadık bundan dolayı viewbag'den faydalanacağım.

            ViewBag.List = list;

            return View(new TodoItem());
        }

        [HttpPost]
        public PartialViewResult Calendar(TodoItem todoItem)
        {
            List<TodoItem> list = null;
            
            if(Session["todolist"] != null)
            {
                list = Session["todolist"] as List<TodoItem>;
            }

            else
            {
                list = new List<TodoItem>();
            }

            todoItem.Id = Guid.NewGuid();
            //Id boş Guid Empty oluyor NewGuid ile yenisini üretip atıyorum.
            
            list.Add(todoItem);

            Session["todolist"] = list;

            System.Threading.Thread.Sleep(3000);

            return PartialView("_TodoPartialView",todoItem);
        }
    }
}
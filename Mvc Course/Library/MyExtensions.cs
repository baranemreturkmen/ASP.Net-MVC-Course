using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Mvc_Course.Library
{
    public static class MyExtensions
    {
        //Extension metodun bulunduğu class static olmalı dolayısıyla metodun kendisi de static olacak.

        public static MvcHtmlString Button(this HtmlHelper helper, string id="",ButtonType type=ButtonType.button,string text="")
        {
            //Helper metodlar MvcHtmlString tipinde dönüyor.
            //Extension metodun html helper içerisinde çıkmasını istiyorum. Bu durumda metoda o tipte bir parametre tanımlamam yeterli olacaktır.

            string html = string.Format("<button id='{0}' name='{0}' type='{1}'>{2}</button", id, type.ToString(), text);

            return MvcHtmlString.Create(html);
            //MvcHtmlString Create metodu verilen bir string'i html'e çevirir.
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string id = "",string cssClass="", ButtonType type = ButtonType.button, string text = "")
        {
            //Tag Builder sınıfından faydalanarak custom html metod oluşturuyorum.

            TagBuilder tag = new TagBuilder("button"); //-> <button></button
            tag.AddCssClass(cssClass); //-> <button class=''></button        
            tag.GenerateId(id);//-> <button id='' class='btn' class=btn-success></button

            //-> <button id='' class='btn' class=btn-success type="button"></button
            tag.Attributes.Add(new KeyValuePair<string, string>("type", type.ToString()));
            
            //-> <button id='' class='btn' class=btn-success type='button' name=''></button
            tag.Attributes.Add(new KeyValuePair<string, string>(("name"), id));

            tag.SetInnerText(text);//-> <button id='' class='btn' class=btn-success type='button' name=''>text</button

            return MvcHtmlString.Create(tag.ToString());
        }

        public static MvcHtmlString Paragraph(this HtmlHelper helper, string id = "", int borderSize = 3, string borderType="solid",
            Func<object,HelperResult> template = null)
        {

            //Func<object,HelperResult> template fonksiyon oluşturdum aslında.
            //template fonksiyonu obje alıyor başlangıç değeri olarak, HelperResult dönüyor daha sonra.

            string html = string.Format("<p id='{0}' name='{0}' style='border-width:{1}px; border-style:{2}'>{3}</p", id, borderSize, borderType,template.Invoke(null));

            //Invoke metodu ile oluşturduğum fonksiyonu çağırıyorum. Verdiğim html'i alıp paragraf içerisine koyacak.

            return MvcHtmlString.Create(html);
            
        }
    }

    public enum ButtonType
    {
        button = 0,
        submit = 1,
        reset = 2
    }
}
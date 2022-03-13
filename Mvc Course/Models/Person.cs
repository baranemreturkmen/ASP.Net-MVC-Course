using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Course.Models
{
    public class Person
    {
        //Controllerdan View'a veri aktarırken bu sınıfı kullanacağım.
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        
        //Age veri tipi integer. Eğer string vs. farklı veri tipi girmeye kalkarsam bu değere frontend tarafında textbox içerisine
        //bu veriyi backende almaya çalıştığımda integerın default değeri olan 0 dönecektir. Mvc girdiğim değeri int'e dönüştüremediği 
        //için integerın default değerini kullanacaktır.
    }
}
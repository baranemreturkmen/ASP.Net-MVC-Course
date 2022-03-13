using Mvc_Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Course.ViewModels
{
    public class ApplicationsPageViewModel
    {
        public Person Student { get; set; }
        public Address HomeAddress { get; set; }
    }
}
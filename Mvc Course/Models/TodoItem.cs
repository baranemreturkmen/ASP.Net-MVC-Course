using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_Course.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string Text { get; set; }
    }
}
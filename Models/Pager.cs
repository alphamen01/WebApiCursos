using System;
using System.Collections.Generic;

namespace WebApiCursos.Models
{
    public class Pager
    {
        public List<Course> Courses { get; set; } = new List<Course>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public int Records { get; set; }

    }
}

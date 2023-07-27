using System;
using System.Collections.Generic;

namespace WebApiCursos.Models
{
    public class Pager
    {
        /*
        public List<Course> Courses { get; set; } = new List<Course>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public int Records { get; set; }
        */

        public List<Course> Courses { get; set; } = new List<Course>();

        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSiZe { get; set; }
        public int TotalPages { get; set; }
        public int StarPage { get; set; }
        public int EndPage { get; set; }

        public Pager()
        {
            
        }

        public Pager(int totalItems, int page, int pageSize )
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSiZe = pageSize;
            TotalPages = totalPages;
            StarPage = startPage;
            EndPage = endPage;
            

        }


    }
}

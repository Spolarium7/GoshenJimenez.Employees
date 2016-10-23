using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoshenJimenez.Employees.DAL
{
    public class Paged<T>
    {
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public string Keyword { get; set; }
        public string SortBy { get; set; }
        public bool IsAscending { get; set; }
    }
}
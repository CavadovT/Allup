using System.Collections.Generic;

namespace Allup.ViewModels
{
    public class CategoryVM<T>
    {
        public List<T> Items { get; set; }
        public List<T> SubItems { get; set; }
        public int PageCount { get; set; }
        public int PageCountSub { get; set; }
        public int CurrentPage { get; set; }

        public CategoryVM(List<T> items, List<T> subitem, int pageCount,int pageCountSub, int currentPage)
        {
            Items = items;
            SubItems = subitem;
            PageCount = pageCount;
            CurrentPage = currentPage;
            PageCountSub= pageCountSub;

        }
    }
}

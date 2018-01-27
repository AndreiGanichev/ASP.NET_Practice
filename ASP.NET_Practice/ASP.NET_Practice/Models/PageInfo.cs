using ASP.NET_Practice.DataAccess.SingleEntityRepo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Practice.Models
{
    /// <summary>
    /// Модель для постраничного вывода коллекции
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageInfo<T> where T : IBaseId
    {
        public PageInfo(IQueryable<T> allItems, int pageNumber, int itemsPerPage = 20)
        {
            var allItemsCount = (double)allItems.Count();
            TotalPageNumber = (int)Math.Ceiling(allItemsCount/itemsPerPage);
            ItemsPerPage = itemsPerPage;
            CurrentPageNumber = pageNumber;
            ItemsOnPage = allItems.OrderBy(i => i.Id).Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage);
        }

        public IEnumerable<T> ItemsOnPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPageNumber { get; set; }
        public int TotalPageNumber { get; set; }
    }
}
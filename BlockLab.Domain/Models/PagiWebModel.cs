using System;
using System.Collections.Generic;
using System.Text;

namespace BlockLab.Domain.Models
{
    /// <summary> Пагинация </summary>
    public class PagiWebModel
    {
        /// <summary> Номер страницы </summary>
        public int Page { get; set; }
        /// <summary> Размер страницы </summary>
        public int PageSize { get; set; }
        /// <summary> Всего отобранных товаров </summary>
        public int Count { get; set; }
        /// <summary> Начальный номер, для отображения порядковых номеров </summary>
        public int StartNumber { get; set; }

        public PagiWebModel(int page, int count, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
            Count = count;
            StartNumber = (page - 1) * pageSize + 1;
        }
        /// <summary> Всего страниц </summary>
        public int CountPages => PageSize == 0 ? 0 : (int)Math.Ceiling((double)Count / PageSize);
        /// <summary> Есть еще другие страницы </summary>
        public bool HasMorePrevPage => Page > 4;
        /// <summary> Есть первая страница </summary>
        public bool HasFirstPage => Page > 3;
        /// <summary> Есть ранее предидущей страница </summary>
        public bool HasPrevPreviousPage => Page > 2;
        /// <summary> Есть предидущая страница </summary>
        public bool HasPreviousPage => Page > 1;
        /// <summary> Есть следущая страница </summary>
        public bool HasNextPage => (Page < CountPages);
        /// <summary> Есть позднее следущей страница </summary>
        public bool HasNextNextPage => (Page < CountPages - 1);
        /// <summary> Есть последняя страница </summary>
        public bool HasLastPage => (Page < CountPages - 2);
        /// <summary> Есть еще другие страницы </summary>
        public bool HasMoreLastPage => (Page < CountPages - 3);
    }
}

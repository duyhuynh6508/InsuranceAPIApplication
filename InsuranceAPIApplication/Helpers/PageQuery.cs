using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceAPIApplication.Helpers
{
    public class PageQuery
    {
        public int CurrentPage { get; }
        public int PageSize { get; }

        public PageQuery(int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        /// <summary>
        /// This method will return page query that is valid. Either itself or a default with 1.
        /// Defaults page size to 1 if page size &lt; 0
        /// </summary>
        public PageQuery Normalise(int defaultPageSize = 7) => IsValid()
            ? this : new PageQuery(1, PageSize > 0 ? PageSize : defaultPageSize);

        /// <summary>
        /// This method just returns the boolean validation flag for currentPage and page size
        /// </summary>
        /// <returns>boolean true / false results</returns>
        public bool IsValid() => CurrentPage > 0 && PageSize > 0;
    }
}
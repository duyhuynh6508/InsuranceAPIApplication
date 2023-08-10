using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceAPIApplication.Helpers
{
    public class PageListModel<T>
    {
        public List<T> Items { get; }

        public int CurrentPage { get; }
        public int PageSize { get; }
        public int TotalCount { get; }

        public PageListModel(List<T> items, int currentPage, int pageSize, int totalCount)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public PageListModel<T2> Convert<T2>(Func<T, T2> convertFunction)
        {
            var rowItems = Items.Select(convertFunction).ToList();
            return new PageListModel<T2>(rowItems, CurrentPage, PageSize, TotalCount);
        }

        /// <summary>
        /// Get a paged list of items from an ordered query.
        /// </summary>
        /// <param name="query">The query (which must be ordered for consistent results)</param>
        /// <param name="currentPage">The current page</param>
        /// <param name="pageSize">The current size of the page</param>
        /// <returns>A page list model generated from the query</returns>
        public static PageListModel<T> FromOrderedQuery(IQueryable<T> query, int currentPage, int pageSize)
        {
            // currentPage and pageSize must be at least one
            currentPage = Math.Max(1, currentPage);
            pageSize = Math.Max(1, pageSize);

            int itemsToSkip = (currentPage - 1) * pageSize;
            List<T> items = query.Skip(itemsToSkip).Take(pageSize).ToList();
            int totalCount = query.Count();

            return new PageListModel<T>(items, currentPage, pageSize, totalCount);
        }

        /// <summary>
        /// Get a paged list of items from an ordered query.
        /// </summary>
        /// <param name="query">The query (which must be ordered for consistent results)</param>
        /// <param name="convertFunction">A function to convert the database DTO into the model returned</param>
        /// <param name="currentPage">The current page</param>
        /// <param name="pageSize">The current size of the page</param>
        /// <returns>A page list model generated from the query</returns>
        public static PageListModel<T> FromOrderedQuery<T2>(IQueryable<T2> query, Func<T2, T> convertFunction,
            int currentPage, int pageSize)
        {
            // currentPage and pageSize must be at least one
            currentPage = Math.Max(1, currentPage);
            pageSize = Math.Max(1, pageSize);

            int itemsToSkip = (currentPage - 1) * pageSize;
            List<T> items = query.Skip(itemsToSkip).Take(pageSize).AsEnumerable().Select(convertFunction).ToList();
            int totalCount = query.Count();

            return new PageListModel<T>(items, currentPage, pageSize, totalCount);
        }

        /// <summary>
        /// Get a paged list of items from an ordered query.
        /// </summary>
        /// <param name="query">The query (which must be ordered for consistent results)</param>
        /// <param name="currentPage">The current page</param>
        /// <param name="pageSize">The current size of the page</param>
        /// <param name="cancellationToken">A token that can be used to cancel the query</param>
        /// <returns>A page list model generated from the query</returns>
        public static PageListModel<T> FromOrderedQueryAsync(IQueryable<T> query, int currentPage,
            int pageSize)
        {
            // currentPage and pageSize must be at least one
            currentPage = Math.Max(1, currentPage);
            pageSize = Math.Max(1, pageSize);

            int itemsToSkip = (currentPage - 1) * pageSize;
            List<T> items = query.Skip(itemsToSkip).Take(pageSize).ToList();
            int totalCount = query.Count();

            return new PageListModel<T>(items, currentPage, pageSize, totalCount);
        }

        /// <summary>
        /// Get a paged list of items from an ordered query.
        /// </summary>
        /// <param name="query">The query (which must be ordered for consistent results)</param>
        /// <param name="convertFunction">A function to convert the database DTO into the model returned</param>
        /// <param name="currentPage">The current page</param>
        /// <param name="pageSize">The current size of the page</param>
        /// <param name="cancellationToken">A token that can be used to cancel the query</param>
        /// <returns>A page list model generated from the query</returns>
        public static PageListModel<T> FromOrderedQueryAsync<T2>(IQueryable<T2> query,
            Func<T2, T> convertFunction, int currentPage, int pageSize)
        {
            // currentPage and pageSize must be at least one
            currentPage = Math.Max(1, currentPage);
            pageSize = Math.Max(1, pageSize);

            int itemsToSkip = (currentPage - 1) * pageSize;
            List<T2> returnedDtos = query.Skip(itemsToSkip).Take(pageSize).ToList();
            List<T> items = returnedDtos.Select(convertFunction).ToList();
            int totalCount = query.Count();

            return new PageListModel<T>(items, currentPage, pageSize, totalCount);
        }
    }
}
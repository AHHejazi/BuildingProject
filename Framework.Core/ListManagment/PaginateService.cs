using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Core.ListManagment
{
    public static class PaginateService
    {
        /// <summary>
        /// Paginates your query and returns Page object for the given page number and page size.
        /// Note: OrderBy is mandatory for the pagination to work.
        /// </summary>
        /// <typeparam name="T">Type of Entity for which pagination is being implemented.</typeparam>
        /// <param name="query">IQueryable on which pagination will be applied.</param>
        /// <param name="pageNumber">The page no. which needs to be fetched.</param>
        /// <param name="pageSize">The number or records expected in the page.</param>
        /// <returns>A Page object with filtered data for the given page number and page size.</returns>
        public async static Task<Page<T>> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            try
            {
                var skipRecords = (pageNumber - 1) * pageSize;

                var resultData =  query.Skip(skipRecords).Take(pageSize);

                var result = new Page<T>
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    RecordCount = query.Count(),
                    Results = await resultData.ToListAsync()
                };
                result.PageCount = (int)Math.Ceiling((double)result.RecordCount / pageSize);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }

        /// <summary>
        /// Paginates your query and returns Page object for the given page number and page size.
        /// </summary>
        /// <typeparam name="T">Type of Entity for which pagination is being implemented.</typeparam>
        /// <param name="query">IQueryable on which pagination will be applied.</param>
        /// <param name="pageNumber">The page no. which needs to be fetched.</param>
        /// <param name="pageSize">The number or records expected in the page.</param>
        /// <param name="sorts">Conditional sorts.</param>
        /// <returns>A Page object with filtered data for the given page number and page size.</returns>
        public async static Task<Page<T>> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize, Sorts<T> sorts)
        {
            return await query.ApplySort(sorts).Paginate(pageNumber, pageSize);
        }

        /// <summary>
        /// Paginates your query and returns Page object for the given page number and page size.
        /// </summary>
        /// <typeparam name="T">Type of Entity for which pagination is being implemented.</typeparam>
        /// <param name="query">IQueryable on which pagination will be applied.</param>
        /// <param name="pageNumber">The page no. which needs to be fetched.</param>
        /// <param name="pageSize">The number or records expected in the page.</param>
        /// <param name="sorts">Conditional sorts.</param>
        /// <param name="filters">Conditional filters.</param>
        /// <returns>A Page object with filtered data for the given page number and page size.</returns>
        public async static Task<Page<T>> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize, Sorts<T> sorts, Filters<T> filters)
        {
            return await query.ApplyFilter(filters).Paginate(pageNumber, pageSize, sorts);
        }

        public async static Task<Page<T>> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize, Filters<T> filters)
        {
            return await query.ApplyFilter(filters).Paginate(pageNumber, pageSize);
        }


        private  static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, Filters<T> filters)
        {
            return !filters.IsValid() ? query : filters.Get().Aggregate(query, (current, filter) => current.Where(filter.Expression));
        }

        private static IQueryable<T> ApplySort<T>(this IQueryable<T> query, Sorts<T> sorts)
        {
            if (!sorts.IsValid()) return query;
            return Sorts<T>.ApplySorts(query, sorts);
        }
    }
}
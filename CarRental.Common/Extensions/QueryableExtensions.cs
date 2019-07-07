using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRental.Common.Foundation.Paging;

namespace CarRental.Common.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool shouldFilter, Expression<Func<TSource, bool>> predicate)
        {
            return shouldFilter ? source.Where(predicate) : source;
        }

        public static Task<IPagedList<TSource>> ToPagedListAsync<TSource>(this IQueryable<TSource> source, IPagedFilter filter)
        {
            return source.ToPagedListAsync(filter, x => x);
        }

        public static async Task<IPagedList<TResult>> ToPagedListAsync<TSource, TResult>(this IQueryable<TSource> source, IPagedFilter filter, Expression<Func<TSource, TResult>> map)
        {
            filter = filter ?? new PagedFilter();
            var count = await source.LongCountAsync();

            if (count == 0 || filter.Take == 0)
            {
                return new PagedList<TResult>
                {
                    Take = filter.Take,
                    Skip = filter.Skip,
                    Total = count,
                    Results = new List<TResult>()
                };
            }

            var results = await source
                .Skip(filter.Skip)
                .Take(filter.Take)
                .ToListAsync();

            var func = map.Compile();

            return new PagedList<TResult>
            {
                Take = filter.Take,
                Skip = filter.Skip,
                Total = count,
                Results = results.Select(func).ToList()
            };
        }

        public static IOrderedQueryable<TSource> SortBy<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, bool isDescending = false)
        {
            return isDescending ? source.OrderByDescending(keySelector) : source.OrderBy(keySelector);
        }

        public static IOrderedQueryable<TSource> SortByX<TSource>(this IQueryable<TSource> source, Func<IQueryable<TSource>, IOrderedQueryable<TSource>> keySelector)
        {
            return keySelector(source);
        }

    }
}

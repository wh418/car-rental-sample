using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Common.Foundation.Paging
{
    public static class PagingExtensions
    {
        public static IPagedList<TResult> ToPagedList<TSource, TResult>(this IPagedList<TSource> sourceList, Func<IEnumerable<TSource>, IList<TResult>> selector)
        {
            return new PagedList<TResult>
            {
                Results = selector(sourceList.Results),

                Total = sourceList.Total,
                Take = sourceList.Take,
                Skip = sourceList.Skip
            };
        }

        public static async Task<IPagedList<TSource>> ToPagedListAsync<TSource>(this IPagedList<Task<TSource>> sourceList)
        {
            var list = await Task.WhenAll(sourceList.Results).ConfigureAwait(false);

            return new PagedList<TSource>
            {
                Results = list,

                Total = sourceList.Total,
                Take = sourceList.Take,
                Skip = sourceList.Skip
            };
        }

        public static IPagedList<TResult> ToEmptyPagedList<TSource, TResult>(this IPagedList<TSource> sourceList)
        {
            if (sourceList != null && (sourceList.Total != 0 || sourceList.Results.Count != 0))
                throw new ArgumentException("PagingExtensions.ToEmptyPagedList - PagedList isn't empty");

            return new PagedList<TResult>
            {
                Results = new List<TResult>(),

                Total = sourceList?.Total ?? 0,
                Take = sourceList?.Take ?? PagingConstants.DefaultPageSize,
                Skip = sourceList?.Skip ?? 0
            };
        }

        public static TGroup ToPagedList<TGroup, TSource, TResult>(this IPagedList<TSource> sourceList, Func<IEnumerable<TSource>, IList<TResult>> selector) where TGroup : IPagedList<TResult>, new()
        {
            return new TGroup
            {
                Results = selector(sourceList.Results),

                Total = sourceList.Total,
                Take = sourceList.Take,
                Skip = sourceList.Skip
            };
        }

        public static TGroup ToEmptyPagedList<TGroup, TSource, TResult>(this IPagedList<TSource> sourceList) where TGroup : IPagedList<TResult>, new()
        {
            if (sourceList != null && (sourceList.Total != 0 || sourceList.Results.Count != 0))
                throw new ArgumentException("PagingExtensions.ToEmptyPagedList - PagedList isn't empty");

            return new TGroup
            {
                Results = new List<TResult>(),

                Total = sourceList?.Total ?? 0,
                Take = sourceList?.Take ?? PagingConstants.DefaultPageSize,
                Skip = sourceList?.Skip ?? 0
            };
        }
    }
}
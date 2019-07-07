using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Common.Extensions
{

    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T, int> action)
        {
            var i = 0;
            foreach (var item in list)
            {
                action(item, i);
                i++;
            }
        }

        public static T AddAndReturn<T>(this ICollection<T> list, T value)
        {
            list.Add(value);
            return value;
        }

        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool shouldFilter, Func<TSource, bool> predicate)
        {
            return shouldFilter ? source.Where(predicate) : source;
        }

        public static string JoinString(this IEnumerable<string> source, string separator)
        {
            return string.Join(separator, source);
        }
    }
}

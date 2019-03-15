using System;
using System.Collections.Generic;
using Lab.Entities;

namespace Lab
{
    public static class MyOwnLinq
    {
        public static IEnumerable<Tsource> JoeyWhere<Tsource>(this List<Tsource> sources, Func<Tsource, bool> predicate)
        {
            var enumerator = sources.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    yield return current;
                }
            }
        }

        public static IEnumerable<Tsource> JoeyWhere<Tsource>(this List<Tsource> sources,
            Func<Tsource, int, bool> predicate)
        {
            var enumerator = sources.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current, index++))
                {
                    yield return current;
                }
            }
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> sources,
            Func<TSource, TResult> selector)
        {
            var enumerator = sources.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                yield return selector(current);
            }
        }

        public static IEnumerable<TResult> JoeySelect<TSource, TResult>(this IEnumerable<TSource> sources,
            Func<TSource, int, TResult> selector)
        {
            var enumerator = sources.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                yield return selector(current, index++);
            }
        }

        public static IEnumerable<Employee> JoeyTake(this IEnumerable<Employee> employees, int takeCount)
        {
            var enumerator = employees.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (index++ < takeCount)
                {
                    yield return current;
                }
            }
        }

        public static IEnumerable<Employee> JoeySkip(this IEnumerable<Employee> employees)
        {
            var enumerator = employees.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (index >= 2)
                {
                    yield return current;
                }

                index++;
            }
        }
    }
}
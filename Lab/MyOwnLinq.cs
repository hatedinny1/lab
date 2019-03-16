using Lab.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
                if (index < takeCount)
                {
                    yield return current;
                }
                else
                {
                    yield break;
                }
                index++;
            }
        }

        public static IEnumerable<TSource> JoeySkip<TSource>(this IEnumerable<TSource> employees, int skipCount)
        {
            var enumerator = employees.GetEnumerator();
            var index = 0;
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (index >= skipCount)
                {
                    yield return current;
                }

                index++;
            }
        }

        public static IEnumerable<int> JoeyGroupSum<TSource>(this IEnumerable<TSource> products, Func<TSource, int> selector)
        {
            var pageIndex = 0;
            var pageSize = 3;
            while (products.Count() >= pageSize * pageIndex)
            {
                yield return products.Skip(pageIndex++ * pageSize).Take(pageSize).Sum(selector);
            }
        }

        public static IEnumerable<Card> JoeyTakeWhile(this IEnumerable<Card> cards, Func<Card, bool> predicate)
        {
            var enumerator = cards.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    yield return current;
                }
                else
                {
                    yield break;
                }
            }
        }

        public static bool JoeyAll(this IEnumerable<Girl> girls, Func<Girl, bool> predicate)
        {
            var enumerator = girls.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (!predicate(current))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool JoeyAny(this IEnumerable<Product> products, Func<Product, bool> predicate)
        {
            var enumerator = products.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (predicate(current))
                {
                    return true;
                }
            }
            return false;
        }

        public static TSource JoeyFirstOrDefault<TSource>(this IEnumerable<TSource> sources)
        {
            var enumerator = sources.GetEnumerator();
            return enumerator.MoveNext() ? enumerator.Current : default(TSource);
        }

        public static TSource JoeyLastOrDefault<TSource>(this IEnumerable<TSource> employees)
        {
            var enumerator = employees.GetEnumerator();
            var last = default(TSource);
            while (enumerator.MoveNext())
            {
                var enumeratorCurrent = enumerator.Current;
                last = enumeratorCurrent;
            }
            return last;
        }

        public static IEnumerable<TSource> JoeyReverse<TSource>(this IEnumerable<TSource> sources)
        {
            return new Stack<TSource>(sources);
        }
    }
}
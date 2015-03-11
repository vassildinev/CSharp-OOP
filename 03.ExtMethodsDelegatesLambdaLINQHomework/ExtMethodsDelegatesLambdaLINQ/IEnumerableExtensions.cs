namespace ExtMethodsDelegatesLambdaLINQHomework
{
    using System;
    using System.Collections.Generic;
    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> enumeration) where T : new()
        {
            dynamic sum = new T();
            foreach (var item in enumeration)
            {
                sum += item;
            }
            return sum;
        }

        public static T Max<T>(this IEnumerable<T> enumeration) where T : IComparable, new()
        {
            dynamic max = new T();
            int count = 0;
            foreach (var item in enumeration)
            {
                if (count == 0)
                {
                    max = item;
                    ++count;
                    continue;
                }

                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }

        public static T Min<T>(this IEnumerable<T> enumeration) where T : IComparable, new()
        {
            dynamic min = new T();
            int count = 0;
            foreach (var item in enumeration)
            {
                if (count == 0)
                {
                    min = item;
                    ++count;
                    continue;
                }

                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }

        public static T Product<T>(this IEnumerable<T> enumeration) where T : IComparable, new()
        {
            dynamic product = 1;
            foreach (var item in enumeration)
            {
                product *= item;
            }
            return product;
        }

        public static T Average<T>(this IEnumerable<T> enumeration) where T : IComparable, new()
        {
            dynamic avg = new T();
            int count = 0;
            foreach (var item in enumeration)
            {
                avg += item;
                ++count;
            }
            return avg / count;
        }

        public static int Occurrences<T>(this IEnumerable<T> enumeration, T specialItem) where T:IComparable, new()
        {
            int counter = 0;
            foreach (var item in enumeration)
            {
                if (item.CompareTo(specialItem)==0)
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}

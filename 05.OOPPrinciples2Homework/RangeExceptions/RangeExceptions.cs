//Problem 3. Range Exceptions

//Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range.
//It should hold error message and a range definition [start … end].
//Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime>
//by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].

namespace RangeExceptions
{
    using System;
    using System.Collections.Generic;
    class RangeExceptions
    {
        static void Main()
        {
            var collection = new List<int>();
            //AddInRange(ref collection, 5);
            AddInRange(ref collection, 120);
            //AddInRange(ref collection, DateTime.Now);
        }


        public static void AddInRange<T>(ref List<T> list, T value) where T : struct
        {
            if (typeof(T) == typeof(int))
            {
                if ((dynamic)value < 0 || (dynamic)value > 100)
                {
                    throw new InvalidRangeException<T>("Integer must be in the range [0...100].");
                }
                list.Add(value);
            }
            else if (typeof(T) == typeof(DateTime))
            {
                if ((dynamic)value < new DateTime(1980, 01, 01) || (dynamic)value > new DateTime(2013, 12, 31))
                {
                    throw new InvalidRangeException<T>("Date must be in the range [01.01.1980...31.12.2013].");
                }
                list.Add(value);
            }

        }
    }
}

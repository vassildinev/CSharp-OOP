//Problem 5. 64 Bit array
//Define a class BitArray64 to hold 64 bit values inside an ulong value.
//Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.

namespace BitArray
{
    using System;
    class BArray
    {
        static void Main()
        {
            Console.BufferHeight = 80;

            ulong value = 255;

            Console.WriteLine("Ulong bit array test: {0}", value);
            BitArray64 bitArr = new BitArray64(value);
            foreach (var item in bitArr)
            {
                Console.Write(item);
            }
            Console.WriteLine("\n");
        }
    }
}

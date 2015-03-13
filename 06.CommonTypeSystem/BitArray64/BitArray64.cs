namespace BitArray
{
    using System;
    using System.Collections;
    public class BitArray64 : IEnumerable
    {
        const int BIT_ARRAY_SIZE = 64;

        private bool[] bitArray;

        public BitArray64(ulong number)
        {
            this.bitArray = new bool[BIT_ARRAY_SIZE];
            ConvertNumber(number, ref this.bitArray);
        }

        private void ConvertNumber(ulong number, ref bool[] p)
        {
            for (int i = 0; i < BIT_ARRAY_SIZE; i++)
            {
                bool bit = ((number >> i) & 1) == 1;
                bitArray[BIT_ARRAY_SIZE - 1 - i] = bit;
            }
        }

        public int this[int index]
        {
            get { return Convert.ToInt32(this.bitArray[index]); }
            set
            {
                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Bit value must be either 0 or 1");
                }
                this.bitArray[index] = Convert.ToBoolean(value);
            }
        }

        public override bool Equals(object obj)
        {
            BitArray64 bitArr = obj as BitArray64;
            for (int i = 0; i < this.bitArray.Length; i++)
            {
                if (this[i]!=bitArr[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return this.bitArray.GetHashCode() ^ BIT_ARRAY_SIZE.GetHashCode();
        }

        public static bool operator ==(BitArray64 arr1, BitArray64 arr2)
        {
            if (arr1.Equals(arr2))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(BitArray64 arr1, BitArray64 arr2)
        {
            if (arr1.Equals(arr2))
            {
                return false;
            }
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in this.bitArray)
            {
                yield return Convert.ToInt32(item);
            }
        }
    }
}

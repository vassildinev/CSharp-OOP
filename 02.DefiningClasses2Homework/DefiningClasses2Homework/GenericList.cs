namespace DefiningClasses2Homework
{
    using System;
    using System.Linq;
    public class GenericList<T>
    {
        const int INITIAL_SIZE = 1 << 4;

        //fields for the Deque class
        private T[] data;
        private int frontIndex;
        private int backIndex;

        // constructor
        public GenericList(uint size = INITIAL_SIZE)
        {
            if (size < 2)
            {
                throw new System.ArgumentException("Size of Deque must be at least 2.");
            }
            this.data = new T[size];
            this.frontIndex = (int)size / 2 - 1;
            this.backIndex = (int)size / 2;
        }

        // methods
        public void AppendFront(T item)
        {
            if (frontIndex == -1)
            {
                this.IncreaseCapacity();
            }
            data[frontIndex] = item;
            --frontIndex;
        }

        public void AppendBack(T item)
        {
            if (backIndex == this.Capacity)
            {
                this.IncreaseCapacity();
            }
            data[backIndex] = item;
            ++backIndex;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new System.IndexOutOfRangeException();
            }

            ++backIndex;
            if (backIndex == this.Count)
            {
                IncreaseCapacity();
            }

            --backIndex;

            for (int i = this.backIndex - 1; i >= this.frontIndex + index + 1; i--)
            {
                this.data[i + 1] = this.data[i];
            }
            this.data[frontIndex + index + 1] = item;

            ++backIndex;
        }

        public T RemoveFront()
        {
            if (this.Count == 0)
            {
                throw new System.InvalidOperationException("Deque is empty.");
            }
            ++frontIndex;
            return data[frontIndex];
        }

        public T RemoveBack()
        {
            if (this.Count == 0)
            {
                throw new System.InvalidOperationException("Deque is empty.");
            }
            --backIndex;
            return data[backIndex];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new System.IndexOutOfRangeException();
            }

            for (int i = this.frontIndex + index + 1 + 1; i < this.backIndex; i++)
            {
                this.data[i - 1] = this.data[i];
            }
            --backIndex;
        }

        public void Clear()
        {
            this.data = new T[INITIAL_SIZE];
            this.frontIndex = (int)INITIAL_SIZE / 2 - 1;
            this.backIndex = (int)INITIAL_SIZE / 2;
        }

        public T PeekFront()
        {
            if (this.Count == 0)
            {
                throw new System.InvalidOperationException("Deque is empty.");
            }
            return data[frontIndex + 1];
        }

        public T PeekBack()
        {
            if (this.Count == 0)
            {
                throw new System.InvalidOperationException("Deque is empty.");
            }
            return data[backIndex - 1];
        }
        public T Max()
        {
            T maxValue = this.data[frontIndex + 1];
            for (int i = frontIndex + 1; i < backIndex; i++)
            {
                if ((dynamic)maxValue < this.data[i])
                {
                    maxValue = this.data[i];
                }
            }
            return maxValue;
        }
        public T Min()
        {
            T minValue = this.data[frontIndex + 1];
            for (int i = frontIndex + 1; i < backIndex; i++)
            {
                if ((dynamic)minValue > this.data[i])
                {
                    minValue = this.data[i];
                }
            }
            return minValue;
        }

        private void IncreaseCapacity()
        {
            T[] currentDequeCopy = this.data;
            uint currentDequeCapacity = (uint)currentDequeCopy.Length;

            uint newDequeCapacity = (uint)INITIAL_SIZE << 1;
            this.data = new T[newDequeCapacity];

            for (int i = 0; i < currentDequeCapacity; i++)
            {
                this.data[i + (newDequeCapacity - currentDequeCapacity) / 2] = currentDequeCopy[i];
            }

            frontIndex += (int)(newDequeCapacity - currentDequeCapacity) / 2;
            backIndex += (int)(newDequeCapacity - currentDequeCapacity) / 2;
        }

        // indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new System.IndexOutOfRangeException();
                }

                return this.data[this.frontIndex + index + 1];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new System.IndexOutOfRangeException();
                }

                this.data[this.frontIndex + index + 1] = value;
            }
        }
        // properties
        public uint Capacity
        {
            get
            {
                return (uint)this.data.Length;
            }
        }

        public uint Count
        {
            get
            {
                return (uint)(this.backIndex - this.frontIndex - 1);
            }
        }
    }
}

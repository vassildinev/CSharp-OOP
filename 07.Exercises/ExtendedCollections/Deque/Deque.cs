namespace ExtendedCollections
{
    public class Deque<T>
    {
        const int INITIAL_SIZE = 1 << 4;

        //fields for the Deque class
        private T[] data;
        private int frontIndex;
        private int backIndex;

        // constructor
        public Deque(uint initialSize = INITIAL_SIZE)
        {
            if (initialSize < 2)
            {
                throw new System.ArgumentException("Size of Deque must be at least 2.");
            }
            this.data = new T[initialSize];
            this.frontIndex = (int)initialSize / 2 - 1;
            this.backIndex = (int)initialSize / 2;
        }

        // methods
        public void AppendFront(T item)
        {
            if (frontIndex == -1)
            {
                this.IncreaseCapacity();
            }
            else
            {
                data[frontIndex] = item;
                --frontIndex;
            }
        }

        public void AppendBack(T item)
        {
            if (backIndex == this.Capacity)
            {
                this.IncreaseCapacity();
            }
            else
            {
                data[backIndex] = item;
                ++backIndex;
            }
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

using System;
using System.Collections;
using System.Collections.Generic;

namespace Task03_03
{
    internal class DynamicArray<T> : ICloneable, IEnumerable<T>
    {
        private T[] array;
        private int capacityMultiplier = 2;

        public DynamicArray()
        {
            this.array = new T[8];
            this.Length = 0;
        }

        public DynamicArray(int capacity)
        {
            this.array = new T[capacity];
            this.Length = 0;
        }

        public DynamicArray(IEnumerable<T> newArray)
        {
            this.array = newArray as T[];
            this.Length = this.array.Length;
        }

        public int Capacity => this.array.Length;

        public int Length { get; private set; }

        public T this[int i]
        {
            get
            {
                if (i > this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.array[i];
            }
        }

        public void Add(T element)
        {
            if (this.Length == this.Capacity)
            {
                Array.Resize(ref this.array, this.Capacity * capacityMultiplier);
            }

            this.Length++;
            this.array[this.Length] = element;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            T[] col = collection as T[];
            int collectionLength = col.Length;
            int newLength = collectionLength + this.Length;
            if (newLength > this.Capacity)
            {
                int multiplierCount = (int)Math.Ceiling((double)newLength / this.Capacity) - 1;
                Array.Resize(ref this.array, this.Capacity * capacityMultiplier * multiplierCount);
            }

            col.CopyTo(this.array, this.Length);
            this.Length += collectionLength;
        }

        public IEnumerator<T> GetEnumerator() => new DynamicArrayEnumerator<T>(this.array, this.Length);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public object Clone()
        {
            return new DynamicArray<T>(this.array)
        }
    }
}

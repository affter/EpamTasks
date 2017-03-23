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
                if (i >= this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.array[i];
            }
        }

        public void Add(T element)
        {
            ResizeArrayIfNeeded();

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
                int multiplierCount = (int)Math.Ceiling((double)collectionLength / this.Capacity);
                Array.Resize(ref this.array, this.Capacity * this.capacityMultiplier * multiplierCount);
            }

            col.CopyTo(this.array, this.Length);
            this.Length += collectionLength;
        }

        public IEnumerator<T> GetEnumerator() => new DynamicArrayEnumerator<T>(this.array, this.Length);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public object Clone()
        {
            return new DynamicArray<T>(this.array);
        }

        public bool Remove(T element)
        {
            int startIndex = Array.IndexOf(this.array, element);
            if (startIndex == -1)
            {
                return false;
            }
            if (startIndex == this.Length - 1)
            {
                this.Length--;
                return true;
            }
            LeftShift(startIndex);
            this.Length--;
            return true;
        }

        public bool Insert(T element, int position)
        {
            if (position > this.Length || position < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            ResizeArrayIfNeeded();

            RightShift(position);
            this.array[position] = element;
            this.Length++;
            return true;
        }

        private void ResizeArrayIfNeeded()
        {
            if (this.Length == this.Capacity)
            {
                Array.Resize(ref this.array, this.Capacity * this.capacityMultiplier);
            }
        }

        private void LeftShift(int startIndex)
        {
            for (int i = startIndex; i < this.array.Length - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
        }

        private void RightShift(int startIndex)
        {
            for (int i = this.Length; i > startIndex; i--)
            {
                this.array[i] = this.array[i - 1];
            }
        }
    }
}

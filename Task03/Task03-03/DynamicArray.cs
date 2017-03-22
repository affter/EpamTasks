using System;
using System.Collections;
using System.Collections.Generic;

namespace Task03_03
{
    internal class DynamicArray<T> : IEnumerable, IEnumerable<T>
    {
        private T[] array;

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
        
        public int Capacity { get; private set; }

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
                this.Capacity *= 2;
                T[] newArray = new T[this.Capacity];
                this.array.CopyTo(newArray, 0);
                this.array = newArray;
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
                this.Capacity += newLength;
                T[] newArray = new T[this.Capacity];
                this.array.CopyTo(newArray, 0);
                this.array = newArray;
            }

            col.CopyTo(this.array, this.Length);
            this.Length += collectionLength;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

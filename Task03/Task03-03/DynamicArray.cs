using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task03_03
{
    public class DynamicArray<T> : ICloneable, IEnumerable<T>, IList<T>, ICollection<T>
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
            this.array = new T[newArray.Count()];
            foreach (var item in newArray)
            {
                this.array[this.Length] = item;
                this.Length++;
            }
        }

        public int Capacity
        {
            get => this.array.Length;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (value < this.Length)
                {
                    this.Length = value;
                }

                Array.Resize(ref this.array, value);
            }
        }

        public int Length { get; private set; }

        public int Count => this.Length;

        public bool IsReadOnly => false;
        
        public T this[int index]
        {
            get
            {
                if (index >= this.Length || index < -this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (index < 0)
                {
                    return this.array[this.Length + index];
                }

                return this.array[index];
            }

            set
            {
                if (index >= this.Length || index < -this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (index < 0)
                {
                    this.array[this.Length + index] = value;
                }

                this.array[index] = value;
            }
        }

        public void Add(T element)
        {
            this.ResizeArrayIfNeeded();

            this.Length++;
            this.array[this.Length] = element;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int collectionLength = collection.Count();
            int newLength = collectionLength + this.Length;
            if (newLength > this.Capacity)
            {
                int multiplierCount = collectionLength / this.Capacity;
                if (collectionLength % this.Capacity != 0)
                {
                    multiplierCount++;
                }

                Array.Resize(ref this.array, this.Capacity * this.capacityMultiplier * multiplierCount);
            }

            foreach (var item in collection)
            {
                this.array[this.Length] = item;
                this.Length++;
            }
        }

        public virtual IEnumerator<T> GetEnumerator() => new DynamicArrayEnumerator<T>(this.array, this.Length);

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

            this.LeftShift(startIndex);
            this.Length--;
            return true;
        }

        public bool Insert(int position, T element)
        {
            if (position > this.Length || position < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

           this.ResizeArrayIfNeeded();

            this.RightShift(position);
            this.array[position] = element;
            this.Length++;
            return true;
        }

        public void Clear()
        {
            this.Length = 0;
        }

        void IList<T>.Insert(int index, T item)
        {
            this.Insert(index, item);
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) > -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(this.array, array, arrayIndex);
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(this.array, item);
        }

        public void RemoveAt(int index)
        {
            if (index >= this.Length || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public T[] ToArray()
        {
            T[] outArray = (T[])this.array.Clone();
            Array.Resize(ref outArray, this.Length);
            return outArray;
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

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
            this.array = newArray.ToArray();
            this.Length = newArray.Count();
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

        protected T[] Arr => this.array;

        int ICollection<T>.Count => this.Length;

        bool ICollection<T>.IsReadOnly => false;

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
            if (this.Length == this.Capacity)
            {
                Array.Resize(ref this.array, this.Capacity * this.capacityMultiplier);
            }

            this.array[this.Length] = element;
            this.Length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int collectionLength = collection.Count();
            int newLength = collectionLength + this.Length;
            if (newLength > this.Capacity)
            {
                int multiplierCount = (int)Math.Ceiling(Math.Log(newLength, this.Capacity));

                Array.Resize(ref this.array, this.Capacity * (int)Math.Pow(2, multiplierCount));
            }

            collection.ToArray().CopyTo(this.array, this.Length);
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

            if (this.Length == this.Capacity)
            {
                Array.Resize(ref this.array, this.Capacity * this.capacityMultiplier);
            }

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
            int index = Array.IndexOf(this.array, item);

            if (index < this.Length)
            {
                return index;
            }

            return -1;
        }

        public void RemoveAt(int index)
        {
            if (index >= this.Length || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.LeftShift(index);
        }

        public T[] ToArray()
        {
            T[] outArray = new T[this.Length];
            this.array.CopyTo(outArray, 0);
            return outArray;
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

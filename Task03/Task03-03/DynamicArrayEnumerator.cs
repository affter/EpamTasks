using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03_03
{
    public class DynamicArrayEnumerator<T> : IEnumerator<T>
    {
        private T[] array;
        private int length;

        public DynamicArrayEnumerator(T[] array, int length)
        {
            this.array = array;
            this.length = length;
            this.CurrentPosition = -1;
        }

        public T Current => this.array[this.CurrentPosition];

        public int CurrentPosition { get; protected set; }
        public int Length => this.length;

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public virtual bool MoveNext()
        {
            ++this.CurrentPosition;
            return this.CurrentPosition != this.Length;
        }

        public void Reset()
        {
            this.CurrentPosition = -1;
        }
    }
}

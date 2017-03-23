using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03_03
{
    internal class DynamicArrayEnumerator<T> : IEnumerator<T>
    {
        private T[] array;
        private int current;
        private int length;
        public T Current => array[this.current];

        public DynamicArrayEnumerator(T[] array, int length)
        {
            this.array = array;
            this.length = length;
            this.current = -1;
        }

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            ++this.current;
            return current != this.length;
        }

        public void Reset()
        {
            this.current = -1;
        }
    }
}

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
        public T Current => array[this.current];

        public DynamicArrayEnumerator(T[] array)
        {
            this.array = array;
            this.current = -1;
        }

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            ++this.current;
            return current != array.Length;
        }

        public void Reset()
        {
            this.current = -1;
        }
    }
}

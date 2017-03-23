using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task03_03;

namespace Task03_04
{
    class CycledDynamicArrayEnumerator<T> : DynamicArrayEnumerator<T>
    {
        public CycledDynamicArrayEnumerator(T[] array, int length) : base(array, length)
        {
        }

        public override bool MoveNext()
        {
            ++this.CurrentPosition;
            if (this.CurrentPosition == this.Length)
            {
                this.CurrentPosition = 0;
            }
            return true;
        }
    }
}

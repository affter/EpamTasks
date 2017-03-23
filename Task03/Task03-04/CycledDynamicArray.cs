using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task03_03;

namespace Task03_04
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray() : base()
        {
        }

        public CycledDynamicArray(int capacity) : base(capacity)
        {
        }

        public CycledDynamicArray(ICollection<T> collection) : base(collection)
        {
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator<T>(this.ToArray(), this.Length);
        }
    }
}

using System;
using System.Threading;
using System.Linq;
using Task04_01;

namespace Task04_03
{
    internal class SortingUnit
    {
        public event Action SortComplete;

        public void QSort<T>(T[] array, Func<T, T, bool> comparisonMethod) => CustomSort.QSort(array, comparisonMethod);

        public void ThreadedSort<T>(T[] array, Func<T, T, bool> comparisonMethod)
        {
            ThreadStart ts = () =>
            {
                QSort(array, comparisonMethod);
                SortComplete?.Invoke();
            };

            Thread work = new Thread(ts);
            work.Start();
        }
    }
}

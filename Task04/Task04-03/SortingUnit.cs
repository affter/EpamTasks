using System;
using System.Threading;
using Task04_01;

namespace Task04_03
{
    internal class SortingUnit
    {
        public event EventHandler SortComplete;

        public void QSort<T>(T[] array, Func<T, T, int> comparisonMethod) => CustomSort.QSort(array, comparisonMethod);

        public void AsyncSort<T>(T[] array, Func<T, T, int> comparisonMethod)
        {
            ThreadStart ts = () =>
            {
                QSort(array, comparisonMethod);
                OnSortComplete();
            };

            Thread work = new Thread(ts);
            work.Start();
        }

        public void OnSortComplete()
        {
            this.SortComplete?.Invoke(this, EventArgs.Empty);
        }
    }
}

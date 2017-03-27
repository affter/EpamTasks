using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04_01
{
    public class CustomSort
    {
        public static void QSort<T>(T[] array, Func<T, T, bool> comparisonMethod) => QSort(array, 0, array.Length - 1, comparisonMethod);

        public static void QSort<T>(T[] array, int first, int last, Func<T, T, bool> comparisonMethod)
        {
            if (comparisonMethod == null)
            {
                throw new ArgumentNullException();
            }

            T temp;
            T x = array[first + ((last - first) / 2)];
            int i = first;
            int j = last;
            while (i <= j)
            {
                while (comparisonMethod(array[j], x))
                {
                    j--;
                }

                while (comparisonMethod(x, array[i]))
                {
                    i++;
                }

                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (i < last)
            {
                QSort(array, i, last, comparisonMethod);
            }

            if (first < j)
            {
                QSort(array, first, j, comparisonMethod);
            }
        }
    }
}

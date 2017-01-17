using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask
{
    class Sort
    {
        public static void QSort(int[] array, int first, int last)
        {
            int temp;
            int x = array[first + (last - first) / 2];
            int i = first;
            int j = last;
            while (i <= j)
            {
                while (array[i] < x) i++;
                while (array[j] > x) j--;
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
                QSort(array, i, last);
            if (first < j)
                QSort(array, first, j);
        }
    }
}


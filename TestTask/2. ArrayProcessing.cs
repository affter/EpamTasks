using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask
{
    class ArrayProcessing
    {
        public static bool Contains(int[] array, int value)
        {
            int first = -1;
            int last = array.Length;
            int n;
            if (value > array[last - 1] || value < array[0])
                return false;
            while (first < last - 1)
            {
                n = (first + last) / 2;
                if (array[n] < value)
                    first = n;
                else
                    last = n;
            }
            if (array[last] == value)
                return true;
            else
                return false;
        }
        public static void Main()
        {
            int[] TestArray = { 3, 4, 65, 1, -5, -239, 33 };
            Sort.QSort(TestArray, 0, TestArray.Length - 1);
            Console.WriteLine(Contains(TestArray, 3));
            Console.WriteLine(Contains(TestArray, 124));
            Console.WriteLine(Contains(TestArray, 64));
            Console.ReadKey();
        }
    }
}

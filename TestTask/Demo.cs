using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask
{
    class Demo
    {
        public static void Next()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void WriteArray(int[] array)
        {
            foreach (int i in array) Console.Write(i + " ");
            Console.Write("\n");
        }
        public static void ExistanceChecker(int[] array, int value)
        {
            if (ArrayProcessing.Contains(array, value))
                Console.WriteLine("Input array contains " + value);
            else
                Console.WriteLine("Input array does not contains " + value);
        }
        public static void CheckRegion(double x, double y)
        {
            if (Region.Contains(x, y))
                Console.WriteLine("Point (" + x + ";" + y + ") is in a region");
            else
                Console.WriteLine("Point (" + x + ";" + y + ") is not in a region");
        }
        public static void Main()
        {
            Console.WriteLine("Task 1: Sort");
            Console.WriteLine("Array: 13 11 0 3 5 7 1 2 -4 -6, 11 -2 ");
            int[] array = { 13, 11, 0, 3, 5, 7, 1, 2, -4, -6, 11, -2 };
            Sort.QuickSort(array);
            Console.Write("Sorted array: ");
            WriteArray(array);
            Next();

            Console.WriteLine("Task 2: Array Processing");
            Console.WriteLine("Array: -6 -4 -2 0 1 2 3 5 7 11 11 13");
            ExistanceChecker(array,3);
            ExistanceChecker(array,103);
            Next();

            Console.WriteLine("Task 3: Region");
            CheckRegion(1, 1);
            CheckRegion(1, 6);
            CheckRegion(6, 1);
            CheckRegion(3.9, 4);
            CheckRegion(-1, 1);
            Next();

            Console.WriteLine("Task 4: Sequence");
            Console.WriteLine("Sum of numbers divisible by 3 or 5 from 1 to 1000 is " + Sequence.Sum());
            Next();

            Console.WriteLine("Task 5: Finder");
            int[] duplicateArray = { 2, 5, 3, 8, 0, 5, 2, 0, 8 };
            Console.WriteLine("Array: 2 5 3 8 0 5 2 0 8");
            Console.WriteLine("Unique number in this array is " + Finder.FindUnique(duplicateArray));
            Next();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task04_01;

namespace Task04_02
{
    internal class Program
    {
        public static bool StringComparisonMethod(string string1, string string2)
        {
            int string1Length = string1.Length;
            int string2Length = string2.Length;

            if (string1Length > string2Length)
            {
                return true;
            }
            else if (string1Length == string2Length)
            {
                if (string.Compare(string1, string2, true) > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void Main(string[] args)
        {
            string[] strings = new string[10];
            var rnd = new Random();
            var stringsCount = strings.Length;

            for (int i = 0; i < stringsCount; i++)
            {
                var tmpCharArray = new char[rnd.Next(1, stringsCount)];
                for (int j = 0; j < tmpCharArray.Length; j++)
                {
                    tmpCharArray[j] = (char)rnd.Next(1072, 1103);
                }

                strings[i] = new string(tmpCharArray);
            }

            Console.WriteLine("Массив строк: ");
            PrintStrings(strings);

            CustomSort.QSort(strings, StringComparisonMethod);

            Console.WriteLine("Отсортированный массив: ");
            PrintStrings(strings);
        }

        private static void PrintStrings(string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                Console.WriteLine(strings[i]);
            }
        }
    }
}

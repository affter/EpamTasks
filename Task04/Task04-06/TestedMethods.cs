using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04_06
{
    internal static class TestedMethods
    {
        public static IEnumerable<int> FindAllPositive(this int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    yield return array[i];
                }
            }
        }

        public static IEnumerable<int> FindAll(this int[] array, Predicate<int> condition)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]))
                {
                    yield return array[i];
                }
            }
        }

        public static IEnumerable<int> FindAllPositiveLinq(this int[] array)
        {
            var a = array.Where(n => n > 0);

            return a;
        }
    }
}

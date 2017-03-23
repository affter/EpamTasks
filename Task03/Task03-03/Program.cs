using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03_03
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var temp = new DynamicArray<int>(new[] { 1, 2, 3, 4, 5 });
            temp.AddRange(new[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }
        }
    }
}

﻿using System;
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
            var temp = new DynamicArray<int>(new[] { 1, 2, 3, 4 });
            temp.AddRange(new[] { 1, 2, 3, 4 });
            for (int i = 0; i < temp.Length; i++)
            {
                Console.WriteLine(temp[i]);
            }
        }
    }
}
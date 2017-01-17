using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask
{
    class Finder
    {
        public static int FindUnique(int[] array)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (int i in array)
            {
                if (set.Contains(i))
                    set.Remove(i);
                else
                    set.Add(i);
            }
            return set.First();
        }
    }
}

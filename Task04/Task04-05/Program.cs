using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04_05
{
    internal static class Program
    {
        public static bool IsPositiveInt(this string content)
        {
            if (!content.Any())
            {
                return false;
            }

            int index = 0;

            while (index < content.Length && content[index] == '0')
            {
                index++;

                if (index == content.Length)
                {
                    return false;
                }
            }

            for (int i = index; i < content.Length; i++)
            {
                if (content[i] < '0' && content[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private static void Main(string[] args)
        {
        }
    }
}

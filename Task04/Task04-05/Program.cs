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

            for (int i = 0; i < content.Length; i++)
            {
                if (!char.IsDigit(content[i]))
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask
{
    class Sequence
    {
        public static int Sum()
        {
            const int a1 = 3,
                            b1 = 5,
                            n = 1000,
                            c1 = a1 * b1,
                            n1 = n / a1,
                            n2 = n / b1,
                            n3 = n / c1,
                            sum1 = a1 * (n1 + 1) * n1,
                            sum2 = b1 * (n2 + 1) * n2,
                            sum3 = c1 * (n3 + 1) * n3;
            return ((sum1 + sum2 - sum3) / 2);
        }
    }
}

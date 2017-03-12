using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee s = new Employee("Поляков", "Вячеслав", new DateTime(1995, 1, 25), DateTime.Now, "Developer");
            Console.WriteLine(s.Experience.ToString());
            Console.WriteLine(s.Position);
        }
    }
}

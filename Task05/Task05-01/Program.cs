using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Backuper backuper = new Backuper(Configuration.WorkingDirectory);
            backuper.StartSupervising();
            Console.ReadKey();
            backuper.StopSupervising();
            backuper.Rollback(DateTime.Now.AddMinutes(-1));
            Console.ReadKey();
            backuper.Rollback(DateTime.Now);
            backuper.StartSupervising();
            Console.ReadKey();
        }
    }
}

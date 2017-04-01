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
            
            FileSystemWatcher watcher = new FileSystemWatcher(Configuration.WorkingDirectory);
            watcher.Changed += (object sender, FileSystemEventArgs e) => Console.WriteLine("changed " + e.Name);
            watcher.Deleted += (object sender, FileSystemEventArgs e) => Console.WriteLine("deleted " + e.Name);
            watcher.Renamed += (object sender, RenamedEventArgs e) => Console.WriteLine(e.OldName + " " + e.Name);
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;

            Console.ReadKey();
        }
    }
}

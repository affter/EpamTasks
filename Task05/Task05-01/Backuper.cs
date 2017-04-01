using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task05_01
{
    internal class Backuper
    {
        private FileSystemWatcher watcher;
        private LinkedList<BackupInfo> backupTable = new LinkedList<BackupInfo>();

        public Backuper(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            this.watcher = new FileSystemWatcher(path);
            watcher.EnableRaisingEvents = true;
            watcher.Created += new FileSystemEventHandler(this.OnCreated);
        }

        private void OnCreated(object sender, FileSystemEventArgs eventArgs)
        {
            string fullPath = eventArgs.FullPath;
            string extention = Path.GetExtension(fullPath);

            if (extention == ".txt" || extention == "")
            {
                var info = new BackupInfo(DateTime.Now, ChangeType.Created);
                if (extention == "")
                {
                    info.IsDirectory = true;
                }
                else
                {
                    info.IsDirectory = false;
                }

                info.FullPath = fullPath;
                
                backupTable.AddLast(info);
                foreach (var item in backupTable)
                {
                    Console.WriteLine(item.IsDirectory);
                    Console.WriteLine(item.BackupDateTime);
                }
            }
        }
    }
}

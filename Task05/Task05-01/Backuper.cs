using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;

namespace Task05_01
{
    internal class Backuper
    {
        private FileSystemWatcher watcher;
        private LinkedList<BackupInfo> backupTable = new LinkedList<BackupInfo>();
        private DateTime startTime;
        private DateTime stopTime;

        public Backuper(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            this.watcher = new FileSystemWatcher(path);
            watcher.IncludeSubdirectories = true;
            watcher.Created += new FileSystemEventHandler(this.OnChange);
            watcher.Deleted += new FileSystemEventHandler(this.OnChange);
            watcher.Changed += new FileSystemEventHandler(this.OnChange);
            watcher.Renamed += new RenamedEventHandler(this.OnRenamed);
        }

        public void StartSupervising()
        {
            if (this.startTime == DateTime.MinValue)
            {
                startTime = DateTime.Now;
            }
            this.watcher.EnableRaisingEvents = true;
        }

        public void StopSupervising()
        {
            stopTime = DateTime.Now;
            this.watcher.EnableRaisingEvents = false;
        }

        private void OnChange(object sender, FileSystemEventArgs eventArgs)
        {
            string fullPath = eventArgs.FullPath;
            string extention = Path.GetExtension(fullPath);

            if (extention == ".txt" || extention == "")
            {
                var info = new BackupInfo(DateTime.Now, eventArgs.ChangeType);
                if (extention == "")
                {
                    info.IsDirectory = true;
                }
                else
                {
                    info.IsDirectory = false;
                }

                info.FullPath = fullPath;
                if (!info.IsDirectory && eventArgs.ChangeType != WatcherChangeTypes.Deleted)
                {
                    while (true)
                    {
                        try
                        {
                            StreamReader sr = new StreamReader(fullPath, Encoding.Default);
                            info.Content = sr.ReadToEnd(); // что делать если lock
                            sr.Close();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }

                backupTable.AddLast(info);
                Console.WriteLine(info.FullPath);
                Console.WriteLine(info.IsDirectory);
                Console.WriteLine(info.BackupChangeType);
                Console.WriteLine(info.BackupDateTime);
                Console.WriteLine(info.Content);
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs eventArgs)
        {
            string fullPath = eventArgs.FullPath;
            string extention = Path.GetExtension(fullPath);

            if (extention == ".txt" || extention == "")
            {
                var info = new BackupInfo(DateTime.Now, eventArgs.ChangeType);
                if (extention == "")
                {
                    info.IsDirectory = true;
                }
                else
                {
                    info.IsDirectory = false;
                }

                info.FullPath = eventArgs.OldFullPath;
                info.Content = fullPath;

                backupTable.AddLast(info);
                Console.WriteLine(info.FullPath);
                Console.WriteLine(info.IsDirectory);
                Console.WriteLine(info.BackupChangeType);
                Console.WriteLine(info.BackupDateTime);
                Console.WriteLine(info.Content);
            }
        }

        public void Rollback(DateTime dateTime)
        {
            string workingDirectory = Configuration.WorkingDirectory;

            DirectoryInfo workDir = new DirectoryInfo(workingDirectory);
            foreach (var item in workDir.GetDirectories())
            {
                item.Delete(true);
            }
            foreach (var item in workDir.GetFiles())
            {
                item.Delete();
            }

            if (dateTime < this.startTime)
            {
                dateTime = this.startTime;
            }

            if (dateTime > this.stopTime)
            {
                dateTime = this.stopTime;
            }

            foreach (BackupInfo backupInfo in backupTable)
            {
                string fullPath = backupInfo.FullPath;
                string content = backupInfo.Content;
                DirectoryInfo directory = new DirectoryInfo(workingDirectory);

                if (backupInfo.BackupDateTime > dateTime)
                {
                    break;
                }

                if (backupInfo.BackupChangeType == WatcherChangeTypes.Changed)
                {
                    if (!backupInfo.IsDirectory)
                    {
                        while (true)
                        {
                            try
                            {
                                using (StreamWriter sw = new StreamWriter(fullPath, false, Encoding.Default))
                                {
                                    sw.WriteLine(content);
                                }
                                break;
                            }
                            catch
                            {
                            }
                        }
                    }
                }

                if (backupInfo.BackupChangeType == WatcherChangeTypes.Renamed)
                {
                    if (backupInfo.IsDirectory)
                    {
                        Directory.Move(fullPath, content);
                    }
                    else
                    {
                        while (true)
                        {
                            try
                            {
                                File.Move(fullPath, content);
                                break;
                            }
                            catch
                            {
                            }
                        }
                    }
                }

                if (backupInfo.BackupChangeType == WatcherChangeTypes.Created)
                {
                    if (backupInfo.IsDirectory)
                    {
                        Directory.CreateDirectory(fullPath);
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter(fullPath, false, Encoding.Default))
                        {
                            sw.WriteLine(content);
                        }
                    }
                }

                if (backupInfo.BackupChangeType == WatcherChangeTypes.Deleted)
                {
                    if (backupInfo.IsDirectory)
                    {
                        Directory.Delete(fullPath);
                    }
                    else
                    {
                        File.Delete(fullPath);
                    }
                }
            }
        }
    }
}

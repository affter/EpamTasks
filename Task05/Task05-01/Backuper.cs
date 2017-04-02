using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            this.watcher.IncludeSubdirectories = true;
            this.watcher.Created += new FileSystemEventHandler(this.OnChange);
            this.watcher.Deleted += new FileSystemEventHandler(this.OnChange);
            this.watcher.Changed += new FileSystemEventHandler(this.OnChange);
            this.watcher.Renamed += new RenamedEventHandler(this.OnRenamed);
        }

        public void StartSupervising()
        {
            string workingDirectory = Configuration.WorkingDirectory;
            FileInfo backupHistory = new FileInfo(Path.Combine(workingDirectory, "history.info"));
            if (this.startTime == DateTime.MinValue)
            {
                this.startTime = DateTime.Now;
            }

            if (backupHistory.Exists && !this.backupTable.Any())
            {
                using (StreamReader sr = new StreamReader(backupHistory.FullName))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] backupInfo = sr.ReadLine().Split(';');
                        WatcherChangeTypes type = (WatcherChangeTypes)Enum.Parse(typeof(WatcherChangeTypes), backupInfo[1]);
                        BackupInfo info = new BackupInfo(DateTime.Parse(backupInfo[0]), type, bool.Parse(backupInfo[2]));
                        info.FullPath = backupInfo[3];
                        info.Content = backupInfo[4];
                        this.backupTable.AddLast(info);
                    }
                }
            }
            else
            {
                foreach (var directory in Directory.GetDirectories(workingDirectory, "*", SearchOption.AllDirectories))
                {
                    BackupInfo backupInfo = new BackupInfo(this.startTime, WatcherChangeTypes.Created, true);
                    backupInfo.FullPath = directory;
                    this.backupTable.AddLast(backupInfo);
                }

                foreach (var file in Directory.GetFiles(workingDirectory, "*.txt", SearchOption.AllDirectories))
                {
                    BackupInfo backupInfo = new BackupInfo(this.startTime, WatcherChangeTypes.Created, true);
                    backupInfo.FullPath = file;
                    backupInfo.Content = File.ReadAllText(file);
                    this.backupTable.AddLast(backupInfo);
                }
            }

            this.watcher.EnableRaisingEvents = true;
        }

        public void StopSupervising()
        {
            this.stopTime = DateTime.Now;
            this.watcher.EnableRaisingEvents = false;
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

            foreach (BackupInfo backupInfo in this.backupTable)
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
                            using (StreamWriter sw = new StreamWriter(fullPath, false, Encoding.Default))
                            {
                                sw.Write(content);
                            }

                            break;
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
                            sw.Write(content);
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

        private void OnChange(object sender, FileSystemEventArgs eventArgs)
        {
            string fullPath = eventArgs.FullPath;
            string extention = Path.GetExtension(fullPath);

            if (extention == ".txt" || extention == string.Empty)
            {
                var info = new BackupInfo(DateTime.Now, eventArgs.ChangeType);
                if (extention == string.Empty)
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

                this.backupTable.AddLast(info);
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs eventArgs)
        {
            string fullPath = eventArgs.FullPath;
            string extention = Path.GetExtension(fullPath);

            if (extention == ".txt" || extention == string.Empty)
            {
                var info = new BackupInfo(DateTime.Now, eventArgs.ChangeType);
                if (extention == string.Empty)
                {
                    info.IsDirectory = true;
                }
                else
                {
                    info.IsDirectory = false;
                }

                info.FullPath = eventArgs.OldFullPath;
                info.Content = fullPath;

                this.backupTable.AddLast(info);
            }
        }
    }
}

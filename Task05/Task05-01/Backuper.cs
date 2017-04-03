using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task05_01
{
    internal class Backuper : IDisposable
    {
        private FileSystemWatcher watcher;
        private LinkedList<BackupInfo> backupTable = new LinkedList<BackupInfo>();

        public Backuper(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            FileInfo backupHistory = new FileInfo(Path.Combine(path, "history.info"));

            if (backupHistory.Exists && !this.backupTable.Any())
            {
                this.GetBackupTableFromHistory(backupHistory);
            }
            else
            {
                this.GetBackupTable(path);
            }

            InitWatcher(path);
        }

        public void StartSupervising()
        {
            this.watcher.EnableRaisingEvents = true;
        }

        public void StopSupervising()
        {
            this.watcher.EnableRaisingEvents = false;
        }

        public void Rollback(DateTime dateTime)
        {
            string workingDirectory = Configuration.WorkingDirectory;

            DirectoryInfo workDir = new DirectoryInfo(workingDirectory);
            ClearWorkingDirectory(workDir);
            
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
                else if (backupInfo.BackupChangeType == WatcherChangeTypes.Renamed)
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
                else if (backupInfo.BackupChangeType == WatcherChangeTypes.Created)
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
                else if (backupInfo.BackupChangeType == WatcherChangeTypes.Deleted)
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

        public void Dispose()
        {
            string path = Path.Combine(this.watcher.Path, "history.info");
            CreateHistory(path);
            WriteHistory(path);

            File.SetAttributes(path, FileAttributes.Hidden);
            this.watcher = null;
            this.backupTable = null;
        }

        private void WriteHistory(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                foreach (BackupInfo info in this.backupTable)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(info.BackupDateTime.ToString());
                    sb.Append(';');
                    sb.Append(info.BackupChangeType.ToString());
                    sb.Append(';');
                    sb.Append(info.IsDirectory.ToString());
                    sb.Append(';');
                    sb.Append(info.FullPath);
                    sb.Append(';');
                    sb.Append(info.Content);
                    sb.Append(';');
                    sw.WriteLine(sb.ToString());
                }
            }
        }

        private static void CreateHistory(string path)
        {
            if (!File.Exists(path))
            {
                using (File.Create(path))
                {
                }
            }
            else
            {
                File.Delete(path);
                using (File.Create(path))
                {
                }
            }
        }

        private void InitWatcher(string path)
        {
            this.watcher = new FileSystemWatcher(path);
            this.watcher.IncludeSubdirectories = true;
            this.watcher.Created += new FileSystemEventHandler(this.OnChange);
            this.watcher.Deleted += new FileSystemEventHandler(this.OnChange);
            this.watcher.Changed += new FileSystemEventHandler(this.OnChange);
            this.watcher.Renamed += new RenamedEventHandler(this.OnRenamed);
        }

        private static void ClearWorkingDirectory(DirectoryInfo workDir)
        {
            foreach (var item in workDir.GetDirectories())
            {
                item.Delete(true);
            }

            foreach (var item in workDir.GetFiles())
            {
                item.Delete();
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

        private void GetBackupTable(string path)
        {
            DateTime startTime = DateTime.Now;
            foreach (var directory in Directory.GetDirectories(path, "*", SearchOption.AllDirectories))
            {
                BackupInfo backupInfo = new BackupInfo(startTime, WatcherChangeTypes.Created, true);
                backupInfo.FullPath = directory;
                this.backupTable.AddLast(backupInfo);
            }

            foreach (var file in Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories))
            {
                BackupInfo backupInfo = new BackupInfo(startTime, WatcherChangeTypes.Created, false);
                backupInfo.FullPath = file;
                backupInfo.Content = File.ReadAllText(file);
                this.backupTable.AddLast(backupInfo);
            }
        }

        private void GetBackupTableFromHistory(FileInfo backupHistory)
        {
            using (StreamReader sr = new StreamReader(backupHistory.FullName))
            {
                while (!sr.EndOfStream)
                {
                    string[] backupInfo = sr.ReadLine().Split(';');
                    WatcherChangeTypes type = (WatcherChangeTypes)Enum.Parse(typeof(WatcherChangeTypes), backupInfo[1]);
                    DateTime date = DateTime.Parse(backupInfo[0]);

                    BackupInfo info = new BackupInfo(date, type, bool.Parse(backupInfo[2]));
                    info.FullPath = backupInfo[3];
                    info.Content = backupInfo[4];
                    this.backupTable.AddLast(info);
                }
            }
        }
    }
}

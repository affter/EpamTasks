using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

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

            this.InitWatcher(path);
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
            this.ClearWorkingDirectory(workDir);

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
                    RollbackChange(backupInfo, fullPath, content);
                }
                else if (backupInfo.BackupChangeType == WatcherChangeTypes.Renamed)
                {
                    RollbackRename(backupInfo, fullPath, content);
                }
                else if (backupInfo.BackupChangeType == WatcherChangeTypes.Created)
                {
                    RollbackCreate(backupInfo, fullPath, content);
                }
                else if (backupInfo.BackupChangeType == WatcherChangeTypes.Deleted)
                {
                    RollbackDelete(backupInfo, fullPath);
                }
            }
        }

        public void Dispose()
        {
            string path = Path.Combine(this.watcher.Path, "history.info");
            CreateHistory(path);
            this.WriteHistory(path);
            File.SetAttributes(path, FileAttributes.Hidden);
            this.watcher = null;
            this.backupTable = null;
        }

        private static void RollbackDelete(BackupInfo backupInfo, string fullPath)
        {
            if (backupInfo.IsDirectory)
            {
                Directory.Delete(fullPath, true);
            }
            else
            {
                File.Delete(fullPath);
            }
        }

        private static void RollbackCreate(BackupInfo backupInfo, string fullPath, string content)
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

        private static void RollbackChange(BackupInfo backupInfo, string fullPath, string content)
        {
            if (!backupInfo.IsDirectory)
            {
                using (StreamWriter sw = new StreamWriter(fullPath, false, Encoding.Default))
                {
                    sw.Write(content);
                }
            }
        }

        private static void RollbackRename(BackupInfo backupInfo, string fullPath, string content)
        {
            if (backupInfo.IsDirectory)
            {
                Directory.Move(content, fullPath);
            }
            else
            {
                while (true)
                {
                    try
                    {
                        File.Move(content, fullPath);
                        break;
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void WriteHistory(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                foreach (BackupInfo info in this.backupTable)
                {
                    char separator = '†';
                    char lineSeparator = '‡';
                    StringBuilder sb = new StringBuilder();
                    sb.Append(info.BackupDateTime.ToString());
                    sb.Append(separator);
                    sb.Append(info.BackupChangeType.ToString());
                    sb.Append(separator);
                    sb.Append(info.IsDirectory.ToString());
                    sb.Append(separator);
                    sb.Append(info.FullPath);
                    sb.Append(separator);
                    sb.Append(info.Content);
                    sb.Append(separator);
                    sb.Append(lineSeparator);
                    sw.Write(sb.ToString());
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
            this.watcher.Created += new FileSystemEventHandler(this.OnCreate);
            this.watcher.Deleted += new FileSystemEventHandler(this.OnDelete);
            this.watcher.Changed += new FileSystemEventHandler(this.OnChange);
            this.watcher.Renamed += new RenamedEventHandler(this.OnRename);
        }

        private void ClearWorkingDirectory(DirectoryInfo workDir)
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

        private void OnCreate(object sender, FileSystemEventArgs eventArgs)
        {
            string fullPath = eventArgs.FullPath;
            string extention = Path.GetExtension(fullPath);
            var info = new BackupInfo(DateTime.Now, WatcherChangeTypes.Created);
            info.FullPath = fullPath;
            DetermineIsDirectory(fullPath, info);

            if (extention == ".txt")
            {
                if (!info.IsDirectory)
                {
                    ReadFileContent(fullPath, info);
                    this.backupTable.AddLast(info);
                }
                else
                {
                    this.backupTable.AddLast(info);
                    foreach (string file in Directory.GetFiles(fullPath))
                    {
                        info.FullPath = Path.Combine(fullPath, file);
                        ReadFileContent(info.FullPath, info);
                        this.backupTable.AddLast(info);
                    }
                }
            }
            else
            {
                if (info.IsDirectory)
                {
                    this.backupTable.AddLast(info);
                    foreach (string file in Directory.GetFiles(fullPath))
                    {
                        info.FullPath = Path.Combine(fullPath, file);
                        ReadFileContent(info.FullPath, info);
                        this.backupTable.AddLast(info);
                    }
                }
            }
        }

        private void OnDelete(object sender, FileSystemEventArgs eventArgs)
        {
            string fullPath = eventArgs.FullPath;
            string extention = Path.GetExtension(fullPath);
            var info = new BackupInfo(DateTime.Now, WatcherChangeTypes.Deleted);
            info.FullPath = fullPath;
            DetermineIsDirectory(fullPath, info);

            if (extention == ".txt")
            {
                this.backupTable.AddLast(info);
            }
            else
            {
                if (info.IsDirectory)
                {
                    this.backupTable.AddLast(info);
                }
            }
        }

        private void OnChange(object sender, FileSystemEventArgs eventArgs)
        {
            string fullPath = eventArgs.FullPath;
            string extention = Path.GetExtension(fullPath);
            var info = new BackupInfo(DateTime.Now, WatcherChangeTypes.Changed);
            info.FullPath = fullPath;
            DetermineIsDirectory(fullPath, info);

            if (info.IsDirectory)
            {
                return;
            }

            if (extention == ".txt")
            {
                ReadFileContent(fullPath, info);
                var last = this.backupTable.Last(n => n.FullPath == info.FullPath);

                if (last.Content == info.Content && last.BackupChangeType != WatcherChangeTypes.Deleted && !last.IsDirectory)
                {
                    return;
                }

                this.backupTable.AddLast(info);
            }
        }

        private static void ReadFileContent(string fullPath, BackupInfo info)
        {
            while (true)
            {
                try
                {
                    StreamReader sr = new StreamReader(fullPath, Encoding.Default);
                    info.Content = sr.ReadToEnd();
                    sr.Close();
                    break;
                }
                catch
                {
                    Thread.Yield();
                }
            }
        }

        private void DetermineIsDirectory(string fullPath, BackupInfo info)
        {
            try
            {
                info.IsDirectory = File.GetAttributes(fullPath).HasFlag(FileAttributes.Directory);
            }
            catch
            {
                var last = this.backupTable.Last(n => n.FullPath == info.FullPath);

                info.IsDirectory = last.IsDirectory;
            }
        }

        private void OnRename(object sender, RenamedEventArgs eventArgs)
        {
            string fullPath = eventArgs.FullPath;
            string oldFullPath = eventArgs.OldFullPath;
            string extention = Path.GetExtension(fullPath);
            string oldExtention = Path.GetExtension(oldFullPath);
            var info = new BackupInfo(DateTime.Now, eventArgs.ChangeType);
            info.IsDirectory = Directory.Exists(fullPath);

            if (extention == ".txt")
            {
                if (oldExtention == ".txt")
                {
                    info.FullPath = fullPath;
                    info.Content = oldFullPath;
                    this.backupTable.AddLast(info);
                }
                else
                {
                    if (info.IsDirectory)
                    {
                        info.FullPath = fullPath;
                        info.Content = oldFullPath;
                        this.backupTable.AddLast(info);
                    }
                    else
                    {
                        info.BackupChangeType = WatcherChangeTypes.Created;
                        info.FullPath = fullPath;
                        ReadFileContent(fullPath, info);
                        this.backupTable.AddLast(info);
                    }
                }
            }
            else
            {
                if (info.IsDirectory)
                {
                    info.FullPath = fullPath;
                    info.Content = oldFullPath;
                    this.backupTable.AddLast(info);
                }
                else if (oldExtention == ".txt")
                {
                    info.FullPath = oldFullPath;
                    info.BackupChangeType = WatcherChangeTypes.Deleted;
                    this.backupTable.AddLast(info);
                }
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
            char[] separator = new char[] { '†' };
            char[] lineSeparator = new char[] { '‡' };
            using (StreamReader sr = new StreamReader(backupHistory.FullName, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    string[] history = sr.ReadToEnd().Split(lineSeparator, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < history.Length; i++)
                    {
                        string[] backupInfo = history[i].Split(separator);
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
}
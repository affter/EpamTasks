using System;
using System.IO;

namespace Task05_01
{
    internal class BackupInfo
    {
        public BackupInfo(DateTime backupDateTime)
        {
            this.BackupDateTime = backupDateTime;
        }

        public BackupInfo(DateTime backupDateTime, WatcherChangeTypes type) : this(backupDateTime)
        {
            this.BackupChangeType = type;
        }

        public BackupInfo(DateTime backupDateTime, WatcherChangeTypes type, bool directory) : this(backupDateTime, type)
        {
            this.IsDirectory = directory;
        }

        public DateTime BackupDateTime { get; }

        public WatcherChangeTypes BackupChangeType { get; set; }

        public string Content { get; set; }

        public string FullPath { get; set; }

        public bool IsDirectory { get; set; }
    }
}
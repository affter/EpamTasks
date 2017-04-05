using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override bool Equals(object obj)
        {
            if (!(obj is BackupInfo))
            {
                return false;
            }

            BackupInfo info = (BackupInfo)obj;

            if (info.BackupChangeType == WatcherChangeTypes.Deleted)
            {
                return false;
            }

            return
                info.FullPath == this.FullPath &&
                info.Content == this.Content &&
                ((info.BackupChangeType == WatcherChangeTypes.Created &&
                this.BackupChangeType != WatcherChangeTypes.Deleted) ||
                (this.BackupChangeType == WatcherChangeTypes.Created &&
                info.BackupChangeType != WatcherChangeTypes.Deleted));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

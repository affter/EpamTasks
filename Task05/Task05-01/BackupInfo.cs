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
        public DateTime BackupDateTime { get; }
        public WatcherChangeTypes BackupChangeType { get; set; }
        public string Content { get; set; }
        public string FullPath { get; set; }
        public bool IsDirectory { get; set; }

        public BackupInfo(DateTime backupDateTime)
        {
            this.BackupDateTime = backupDateTime;
        }

        public BackupInfo(DateTime backupDateTime, WatcherChangeTypes type) : this(backupDateTime)
        {
            this.BackupChangeType = type;
        }

        public BackupInfo(DateTime backupDateTime, WatcherChangeTypes type, bool isDirectory) : this(backupDateTime, type)
        {
            this.IsDirectory = isDirectory;
        }
    }
}

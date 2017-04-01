using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05_01
{
    [Flags]
    internal enum ChangeType : byte
    {
        Created = 0,
        Changed = 1,
        Deleted = 2,
    }
}

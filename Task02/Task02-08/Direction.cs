using System;

namespace Task02_08
{
    [Flags]

    internal enum Direction : byte
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 4,
    }
}

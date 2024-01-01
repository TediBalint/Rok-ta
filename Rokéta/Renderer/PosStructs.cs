using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct COORD
{
    public short X;
    public short Y;
}

[StructLayout(LayoutKind.Sequential)]
public struct Rect
{
    public short Left;
    public short Top;
    public short Right;
    public short Bottom;
}

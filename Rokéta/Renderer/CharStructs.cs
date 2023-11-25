using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
public struct CharUnion
{
	[FieldOffset(0)]
	public char UnicodeChar;
}

[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
public struct CharInfo
{
	[FieldOffset(0)]
	public CharUnion Char;
	[FieldOffset(2)]
	public ushort Attributes;
	public CharInfo(char character = ' ', ConsoleColor? foreground = ConsoleColor.White, ConsoleColor? background = ConsoleColor.Black)
	{
		Char = new CharUnion() { UnicodeChar = character };
		Attributes = (ushort)((int)(foreground ?? 0) | (((int)(background ?? 0)) << 4));
	}
}
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace Roketa.Renderer
{
    internal class Renderer
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteConsoleOutput(IntPtr hConsoleOutput, CharInfo[] lpBuffer, COORD dwBufferSize, COORD dwBufferCoord, ref Rect lpWriteRegion);


		public CharInfo[] Buffer;
        public Renderer(int width, int height)
        {
           
            Buffer = new CharInfo[width * height];
			//CentralizeConsole();

		}

        public ConsoleColor getRandomColor()
        {
            ConsoleColor[] consoleColors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
            Random random = new Random();

            int randomIndex = random.Next(consoleColors.Length);

            ConsoleColor randomColor = consoleColors[randomIndex];
            return randomColor;
        }

        public void FillBufferRandom()
        {
            for (int i = 0; i < Buffer.Length; i++)
            {
                Buffer[i] = new CharInfo(' ', getRandomColor(), getRandomColor());
            }
        }

        public void Render()
        {
            IntPtr handle = GetStdHandle(-11);

            Rect rect = new Rect { Left = 0, Top = 0, Right = (short)Console.WindowWidth, Bottom = (short)Console.WindowHeight };

            WriteConsoleOutput(handle, Buffer, new COORD { X = (short)Console.WindowWidth, Y = (short)Console.WindowHeight }, new COORD { X = 0, Y = 0 }, ref rect);
        }
  //      private void CentralizeConsole()
  //      {
		//	IntPtr consoleHandle = GetConsoleWindow();
		//	[DllImport("user32.dll")]
		//	static extern bool GetWindowRect(IntPtr hwnd, out Rect rectangle);

		//	[DllImport("user32.dll")]
		//	static extern int GetSystemMetrics(int nIndex);
		//	if (consoleHandle != IntPtr.Zero)
		//	{
		//		Rect rect;
		//		if (GetWindowRect(consoleHandle, out rect))
		//		{
		//			int screenWidth = GetSystemMetrics(0); // 0 for screen width
		//			int screenHeight = GetSystemMetrics(1); // 1 for screen height

		//			int windowWidth = (rect.Right - rect.Left);
		//			int windowHeight = rect.Bottom - rect.Top;
		//			Debug.WriteLine(windowHeight + " " + windowWidth);
		//			int newX = (screenWidth - windowWidth) / 2;
		//			int newY = (screenHeight - windowHeight) / 2;

		//			MoveWindow(consoleHandle, newX, newY, windowWidth, windowHeight, true);
		//			Debug.WriteLine(newX + " " + newY);
		//		}
		//		else
		//		{
		//			Console.WriteLine("Failed to get window rectangle.");
		//		}
		//	}
		//	else
		//	{
		//		Console.WriteLine("Console window handle not found.");
		//	}

		//	Console.WriteLine("Console window positioned in the center of the screen.");
		//	Console.ReadLine(); // Keep the console window open
		//}

		//[DllImport("kernel32.dll", SetLastError = true)]
		//private static extern IntPtr GetConsoleWindow();

		//[DllImport("user32.dll", SetLastError = true)]
		//private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
	}
}

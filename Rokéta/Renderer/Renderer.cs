using System.Runtime.InteropServices;


namespace ConsoleRenderer2.Renderer
{
    internal class Renderer
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteConsoleOutput(IntPtr hConsoleOutput, CharInfo[] lpBuffer, COORD dwBufferSize, COORD dwBufferCoord, ref SMALL_RECT lpWriteRegion);


		public CharInfo[] Buffer;
        public Renderer(int width, int height)
        {
            Buffer = new CharInfo[width * height];
        }

        public ConsoleColor getRandomColor()
        {
            ConsoleColor[] consoleColors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
            Random random = new Random();

            // Get a random index within the range of available ConsoleColor values
            int randomIndex = random.Next(consoleColors.Length);

            // Select a random ConsoleColor from the array
            ConsoleColor randomColor = consoleColors[randomIndex];
            return randomColor;
        }

        // Example function to fill the buffer with some data
        public void FillBufferRandom()
        {
            // Fill the buffer with random characters and colors
            for (int i = 0; i < Buffer.Length; i++)
            {
                Buffer[i] = new CharInfo(' ', getRandomColor(), getRandomColor());
            }
        }
        public void Render()
        {
            IntPtr handle = GetStdHandle(-11);

            SMALL_RECT rect = new SMALL_RECT { Left = 0, Top = 0, Right = (short)Console.WindowWidth, Bottom = (short)Console.WindowHeight };

            WriteConsoleOutput(handle, Buffer, new COORD { X = (short)Console.WindowWidth, Y = (short)Console.WindowHeight }, new COORD { X = 0, Y = 0 }, ref rect);
        }
        
    }
}

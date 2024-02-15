using System.Diagnostics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
    public abstract class TextState
    {
        public void UpdateText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, int marginX, int marginY)
        {
			int height = pixels.GetLength(0);
			int width = pixels.GetLength(1);
            int[] pos = getTextPos(width, height, text.Length, marginX, marginY);
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (x == pos[0] && y == pos[0])
					{
						insertText(ref pixels, text, foregroundColor, backgroundColor, ref y, ref x, marginX, marginY);
					}
					else
					{
						pixels[y, x] = new CharInfo(' ', foregroundColor, backgroundColor);
					}
					Debug.WriteLine($"x: {x}, y: {y}");
				}
			}
		}
        protected void insertText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, ref int startY, ref int startX, int marginX, int marginY)
        {
            if(text.Length >= pixels.Length)
            {
				text = text.Substring(0, pixels.Length);
			}
            int height = pixels.GetLength(0);
            int width = pixels.GetLength(1);
            int charIndex = 0;
            for (int y = startY; y < height; y++)
            {
                int start = 0;
                if (y == startY) start = startX;
                for (int x = start; x < width; x++)
                {
                    pixels[y, x] = new CharInfo(text[charIndex], foregroundColor, backgroundColor);
                    charIndex++;
                    if (charIndex >= text.Length)
                    {
                        startX = x;
                        startY = y;
                        return;
                    }
                }
            }
        }
        protected abstract int[] getTextPos(int width, int height, int textLength, int marginX, int marginY);
	}
}

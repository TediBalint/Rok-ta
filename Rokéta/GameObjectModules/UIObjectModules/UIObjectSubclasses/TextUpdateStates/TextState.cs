using System.Diagnostics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
    public abstract class TextState
    {
        public abstract void UpdateText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor);
        protected void insertText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, ref int startY, ref int startX)
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
	}
}

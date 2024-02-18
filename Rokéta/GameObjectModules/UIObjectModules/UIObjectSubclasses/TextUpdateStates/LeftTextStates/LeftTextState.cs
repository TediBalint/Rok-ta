using System.Diagnostics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.LeftTextStates
{
    public abstract class LeftTextState : TextState
    {
        protected override void insertText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, ref int startY, ref int startX, Padding padding)
        {
            int height = pixels.GetLength(0);
            int width = pixels.GetLength(1);

            int charCount = getTextAreaLength(width, height, startX, startY, padding);
            if (charCount == 0)
            {
                pixels[startY, startX] = new CharInfo(' ', foregroundColor, backgroundColor);
                return;
            }
            if (text.Length >= charCount)
            {
                text = text.Substring(0, charCount);
            }
            int charIndex = 0;
            for (int y = startY; y < height; y++)
            {
                int start = 0;
                if (y == startY) start = startX;
                for (int x = start; x < width; x++)
                {
                    if (isNotOnPadX(x, width, padding) && isNotOnPadY(y, height, padding))
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
                    else
                    {
                        pixels[y, x] = new CharInfo(' ', foregroundColor, backgroundColor);
                    }

                }
            }
        }
    }
}

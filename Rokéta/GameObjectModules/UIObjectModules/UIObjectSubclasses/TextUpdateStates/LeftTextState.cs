using System.Diagnostics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
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
            text = getText(text, charCount);
            int charIndex = 0;
            for (int y = startY; y < height; y++)
            {
                insertLine(ref pixels, text, y, ref startY, ref startX, ref charIndex, width, height, padding, foregroundColor, backgroundColor);
            }
        }
    }
}

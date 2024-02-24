using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.StartCordStrategys;
using System.Diagnostics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
    public class LeftTextState : TextState
    {
		protected override void insertText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, ref int startY, ref int startX, Padding padding)
        {
            Debug.WriteLine(pixels.GetLength(0));
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
                if(charIndex <= charCount)
                {
					insertLine(ref pixels, text, y, ref startY, ref startX, ref charIndex, width, height, padding, foregroundColor, backgroundColor);
				}
                
            }
        }
    }
}

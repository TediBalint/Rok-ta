using System.Diagnostics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
    public abstract class TextState
    {
        public void UpdateText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, Padding padding)
        {
			int height = pixels.GetLength(0);
			int width = pixels.GetLength(1);
            int[] pos = getTextPos(width, height, text.Length, padding);
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (x == pos[0] && y == pos[1])
					{
						insertText(ref pixels, text, foregroundColor, backgroundColor, ref y, ref x, padding);
					}
					else
					{
						pixels[y, x] = new CharInfo(' ', foregroundColor, backgroundColor);
					}
					Debug.WriteLine($"x: {x}, y: {y}");
				}
			}
		}
        protected void insertText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, ref int startY, ref int startX, Padding padding)
        {
            
            int height = pixels.GetLength(0);
            int width = pixels.GetLength(1);

			int charCount = getTextAreaLength(width, height, startX,startY, padding);
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
                    if(isOnPadX(x,width,padding) || isOnPadY(y,height,padding))
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
						pixels[y,x] = new CharInfo(' ', foregroundColor, backgroundColor);
					}
                   
                }
            }
        }
		private int getTextAreaLength(int width, int height, int startX, int startY, Padding padding)
		{
			int baseArea = (width - padding.Left - padding.Right) * (height - padding.Top - padding.Bottom);
			if (!isOnPadX(startX, width, padding)) baseArea -= (startX - padding.Left);
			if(!isOnPadY(startY, width, padding)) baseArea -= (startY - padding.Top);
			return Math.Max(baseArea,0);
		}
		private bool isOnPadX(int x, int width, Padding padding) => x >= padding.Left && x < width - padding.Right;
		private bool isOnPadY(int y, int height, Padding padding) => y >= padding.Top && y < height - padding.Bottom;
		protected abstract int[] getTextPos(int width, int height, int textLength, Padding padding);
	}
}

using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.StartCordStrategys;
using System.Diagnostics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
	public abstract class TextState
	{
		public void UpdateText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, Padding padding, IStartCordStrategy startCordStrategy)
		{
			int height = pixels.GetLength(0);
			int width = pixels.GetLength(1);
			int[] pos = startCordStrategy.GetStartCords(width, height, text.Length, padding);
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (x == pos[0] && y == pos[1])
					{
						insertText(ref pixels, text, foregroundColor, backgroundColor, ref y, ref x, padding);
					}
					else if(y < height && x < width)
					{
						pixels[y, x] = new CharInfo(' ', foregroundColor, backgroundColor);
					}
				}
			}
		}
		protected abstract void insertText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, ref int startY, ref int startX, Padding padding);
		protected void insertLine(ref CharInfo?[,] pixels, string text, int y, ref int startX, ref int startY, ref int charIndex, int width, int height, 
			Padding padding, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
		{
			int start = startX;
			for (int x = start; x < width; x++)
			{
				if (isNotOnPadX(x, width, padding) && isNotOnPadY(y, height, padding) && charIndex < text.Length)
				{
					//Debug.WriteLine($"x = {x}, y = {y}, height = {pixels.GetLength(0)}, textLength = {text.Length}, charindex = {charIndex}");
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
		protected string getText(string text, int charCount)
		{
			if (text.Length >= charCount)
			{
				text = text.Substring(0, charCount);
			}
			return text;
		}
		protected int getTextAreaLength(int width, int height, int startX, int startY, Padding padding)
		{
			int baseArea = (width - padding.Left - padding.Right) * (height - padding.Top - padding.Bottom);
			if (!isNotOnPadX(startX, width, padding)) baseArea -= startX - padding.Left;
			if (!isNotOnPadY(startY, width, padding)) baseArea -= startY - padding.Top;
			return Math.Max(baseArea, 0);
		}
		protected bool isNotOnPadX(int x, int width, Padding padding) => x >= padding.Left && x < width - padding.Right;
		protected bool isNotOnPadY(int y, int height, Padding padding) => y >= padding.Top && y < height - padding.Bottom;
		protected int getFilledLines(int width, int textLength, Padding padding) => textLength / (width - padding.Left - padding.Right);
	}
}

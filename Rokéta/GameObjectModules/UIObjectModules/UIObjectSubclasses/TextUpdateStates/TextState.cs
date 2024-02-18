using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
	public abstract class TextState
	{
		
		protected abstract void insertText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, ref int startY, ref int startX, Padding padding);
		protected abstract int[] getTextPos(int width, int height, int textLength, Padding padding);
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
				}
			}
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

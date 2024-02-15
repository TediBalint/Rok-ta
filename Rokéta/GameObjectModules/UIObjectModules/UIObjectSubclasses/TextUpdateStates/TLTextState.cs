using System.Diagnostics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
	public class TLTextState : TextState
	{
		public override void UpdateText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
		{
			int height = pixels.GetLength(0);
			int width = pixels.GetLength(1);

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (x == 0 && y == 0)
					{
						insertText(ref pixels, text, foregroundColor, backgroundColor, ref y, ref x);
					}
					else 
					{
						pixels[y, x] = new CharInfo(' ', foregroundColor, backgroundColor);
					}
					Debug.WriteLine($"x: {x}, y: {y}");
					
				}
			}
		}
	}
}

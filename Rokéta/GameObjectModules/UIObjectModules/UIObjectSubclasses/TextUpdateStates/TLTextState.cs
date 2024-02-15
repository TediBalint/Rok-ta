namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
	public class TLTextState : ITextState
	{
		public void UpdateText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
		{
			int height = pixels.GetLength(0);
			int width = pixels.GetLength(1);

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					char c;
					if (text.Length > y * width + x) c = text[y * width + x];
					else c = ' ';
					pixels[y,x] = new CharInfo(c, foregroundColor, backgroundColor);
				}
			}
		}
	}
}

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.CenterTextStates
{
	public abstract class CenterTextState : TextState
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
			
			int tmp_textLength = text.Length;

		}
	}
}

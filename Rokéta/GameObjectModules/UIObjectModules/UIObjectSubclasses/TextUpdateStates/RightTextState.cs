namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
    public class RightTextState : TextState
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
                if (width - padding.Left - padding.Right <= text.Length - charIndex)
                {
                    insertLine(ref pixels, text, y, ref startX, ref startY, ref charIndex, width, height, padding, foregroundColor, backgroundColor);
                }
                else if (charIndex < text.Length)
                {
                    startX = width - text.Length + charIndex - padding.Right - 1;
                    for (int x = 0; x < startX; x++)
                    {
                        pixels[y, x] = new CharInfo(' ', foregroundColor, backgroundColor);
                    }
                    insertLine(ref pixels, text, y, ref startX, ref startY, ref charIndex, width, height, padding, foregroundColor, backgroundColor);
                }
            }
        }
    }
}

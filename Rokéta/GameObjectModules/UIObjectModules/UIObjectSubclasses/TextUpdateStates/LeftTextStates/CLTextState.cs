namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.LeftTextStates
{
	public class CLTextState : LeftTextState
	{
		protected override int[] getTextPos(int width, int height, int textLength, Padding padding)
		{
			int middle = padding.Top + (height - padding.Top - padding.Bottom)/2;
			int filledLines = getFilledLines(width,textLength, padding);
			if (filledLines % 2 == 1) filledLines++;
			return new int[] {padding.Left, Math.Max(0,middle-filledLines/2)};
		}
	}
}

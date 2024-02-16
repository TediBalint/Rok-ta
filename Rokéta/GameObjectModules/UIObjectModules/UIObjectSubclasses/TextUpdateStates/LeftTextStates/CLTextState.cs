namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.LeftTextStates
{
	public class CLTextState : LeftTextState
	{
		protected override int[] getTextPos(int width, int height, int textLength, Padding padding)
		{
			int filledLines = textLength/(width - padding.Left - padding.Right);
			if (filledLines % 2 == 1) filledLines++;
			return new int[] {padding.Left, Math.Max(0,height/2-filledLines/2)};
		}
	}
}

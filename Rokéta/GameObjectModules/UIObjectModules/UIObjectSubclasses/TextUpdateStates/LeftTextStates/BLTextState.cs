namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.LeftTextStates
{
	public class BLTextState : LeftTextState
	{
		protected override int[] getTextPos(int width, int height, int textLength, Padding padding)
		{
			int linesFilled = getFilledLines(width, textLength, padding);
			return new int[] {padding.Left, height-linesFilled-padding.Bottom-1};
			
		}
	}
}

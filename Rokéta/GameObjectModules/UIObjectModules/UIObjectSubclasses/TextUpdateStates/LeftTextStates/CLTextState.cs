using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.CenterTextStates;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.LeftTextStates
{
	public class CLTextState : LeftTextState
	{
		protected override int[] getTextPos(int width, int height, int textLength, Padding padding)
		{
			return new int[] {padding.Left, height/2};
		}
	}
}

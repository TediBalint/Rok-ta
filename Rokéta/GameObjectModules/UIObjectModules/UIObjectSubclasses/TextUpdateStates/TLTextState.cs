using System.Diagnostics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
	public class TLTextState : TextState
	{
		protected override int[] getTextPos(int width, int height, int textLength, int marginX, int marginY)
		{
			return new int[] {marginX,marginY};
		}
	}
}

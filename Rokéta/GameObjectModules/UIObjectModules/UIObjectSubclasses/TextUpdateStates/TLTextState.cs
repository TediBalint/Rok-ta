using System.Diagnostics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
	public class TLTextState : TextState
	{
		protected override int[] getTextPos(int width, int height, int textLength, Padding padding)
		{
			return new int[] {padding.Left, padding.Top};
		}
	}
}

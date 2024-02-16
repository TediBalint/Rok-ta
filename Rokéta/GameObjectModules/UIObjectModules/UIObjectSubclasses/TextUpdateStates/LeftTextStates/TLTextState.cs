using System.Diagnostics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.LeftTextStates
{
    public class TLTextState : LeftTextState
    {
        protected override int[] getTextPos(int width, int height, int textLength, Padding padding)
        {
            return new int[] { padding.Left, padding.Top };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.RightTextStates
{
	public abstract class RightTextState : TextState
	{
		protected override void insertText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, ref int startY, ref int startX, Padding padding)
		{
			throw new NotImplementedException();
		}
	}
}

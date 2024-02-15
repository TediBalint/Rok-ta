using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
    public interface ITextState
    {
        public void UpdateText(ref CharInfo?[,] pixels, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor);
	}
}

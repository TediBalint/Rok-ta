using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.UIObjectModules.ActiveObjectStrategies
{
	public class LastUIObjectStrat : ActiveObjectStrategy
	{
		public override UIObject GetActive(List<UIObject> uiObjects, Stack<UIObject> lastObjects)
		{
			lastObjects.Pop();
			return lastObjects.Peek();
		}
	}
}

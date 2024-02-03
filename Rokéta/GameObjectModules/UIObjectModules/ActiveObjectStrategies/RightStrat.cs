using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.UIObjectModules.ActiveObjectStrategies
{
	public class RightStrat : ActiveObjectStrategy
	{
		public override UIObject GetActive(List<UIObject> uiObjects, Stack<UIObject> lastObjects)
		{
			UIObject activeObject = lastObjects.Peek();

			List<UIObject> overLappingY = new List<UIObject>();
			for (int i = 0; i < uiObjects.Count; i++)
			{
				if (uiObjects[i].Left > activeObject.Right) overLappingY.Add(uiObjects[i]);
			}
			if (overLappingY.Count < 2) return activeObject;
			int offset = 0;

			do
			{
				overLappingY = GetYOverlapping(overLappingY, activeObject, offset);
				offset += 5;
			} while (overLappingY.Count < 1);

			if (overLappingY.Count == 1) return overLappingY[0];

			UIObject minDistanceObject = overLappingY[0];
			for (int i = 1; i < overLappingY.Count; i++)
			{
				UIObject currObject = overLappingY[i];
				if (activeObject.GetDistance(currObject) < activeObject.GetDistance(minDistanceObject)) minDistanceObject = currObject;
			}
			return minDistanceObject;
		}
	}
}

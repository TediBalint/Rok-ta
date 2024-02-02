using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Rokéta.GameObjectModules.UIObjectModules.ActiveObjectStrategies
{
	public class BottomStrat : ActiveObjectStrategy
	{
		public override UIObject GetActive(List<UIObject> uiObjects, UIObject activeObject)
		{
			List<UIObject> overLappingX = new List<UIObject>();
			for (int i = 0; i < uiObjects.Count; i++)
			{
				if (uiObjects[i].Top < activeObject.Bot) overLappingX.Add(uiObjects[i]);
			}

			if (overLappingX.Count < 2) return activeObject;
			int offset = 0;
			
			do
			{
				overLappingX = GetXOverlapping(overLappingX, activeObject, offset);
				offset += 5;
			} while (overLappingX.Count < 1);

			if(overLappingX.Count == 1) return overLappingX[0];

			UIObject minDistanceObject = overLappingX[0];
			for (int i = 1; i < overLappingX.Count; i++)
			{
				UIObject currObject = overLappingX[i];
				if(activeObject.GetDistance(currObject) < activeObject.GetDistance(minDistanceObject)) minDistanceObject = currObject;
			}
			return minDistanceObject;
        }
	}
}

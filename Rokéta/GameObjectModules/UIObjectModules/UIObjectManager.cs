using Rokéta.GameObjectModules.ConsoleObjectModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.UIObjectModules
{
	public class UIObjectManager
	{
		public List<UIObject> UIObjects;

		public CharInfo[,]? Pixels;
		public UIObjectManager(CharInfo[,]? pixels)
		{
			Pixels = pixels;
		}
		public void UpdateObjects()
		{
			for (int i = 0; i < UIObjects.Count; i++)
			{
				UIObject uiObject = UIObjects[i];
				if (uiObject.IsDisposed)
				{
					UIObjects.Remove(uiObject);
				}
				else
				{
					uiObject.Update(ref Pixels);
				}
			}
		}
	}
}

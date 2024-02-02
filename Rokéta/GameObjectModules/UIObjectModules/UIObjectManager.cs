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
		public List<UIObject> UIObjects = new List<UIObject>();

		public CharInfo[,] Pixels;
		public UIObject ActiveObject { get; private set; }

		private Dictionary<ConsoleKey, ActiveObjectStrategy> activeObjectStrategies = new Dictionary<ConsoleKey, ActiveObjectStrategy>() { };
		private ActiveObjectContext activeObjectContext;
		
		public UIObjectManager(CharInfo[,] pixels)
		{
			activeObjectContext = new ActiveObjectContext();
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
		public void ChangeActiveObject(ConsoleKey consoleKey)
		{
			ActiveObject.Blur();
			activeObjectContext.SetStrategy(activeObjectStrategies[consoleKey]);
			ActiveObject = activeObjectContext.GetActiveGameObject(UIObjects, ActiveObject);
			ActiveObject.Focus();
		}
	}
}

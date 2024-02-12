using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.GameObjectModules.UIObjectModules.ActiveObjectStrategies;
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

		public CharInfo[] Pixels;
		public UIObject ActiveObject { get; private set; }
		private readonly Stack<UIObject> lastObjects = new Stack<UIObject>();
		public bool IsActive { get; private set; }
		private Dictionary<ConsoleKey, ActiveObjectStrategy> activeObjectStrategies = new Dictionary<ConsoleKey, ActiveObjectStrategy>()
		{
			{ConsoleKey.S, new BottomStrat()},
			{ConsoleKey.D, new RightStrat()},
			{ConsoleKey.A, new LeftStrat()},
			{ConsoleKey.W, new TopStrat()},
			{ConsoleKey.Z, new LastUIObjectStrat()}
		};

		private ActiveObjectContext activeObjectContext;
		public UIObjectManager(CharInfo[] pixels, bool isActive = false)
		{
			IsActive = isActive;
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
			lastObjects.Push(ActiveObject);
			ActiveObject.Blur();
			activeObjectContext.SetStrategy(activeObjectStrategies[consoleKey]);
			ActiveObject = activeObjectContext.GetActiveGameObject(UIObjects, lastObjects);
			ActiveObject.Focus();
		}
		public void Activate() => IsActive = true;
		public void Deactivate() => IsActive = false;
	}
}

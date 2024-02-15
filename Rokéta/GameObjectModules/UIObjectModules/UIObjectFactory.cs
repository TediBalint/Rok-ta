using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.ButtonModules;
using static Rokéta.GameObjectModules.UIObjectModules.UIObject;

namespace Rokéta.GameObjectModules.UIObjectModules
{
	public class UIObjectFactory
	{
		private UIObjectManager uiObjectManager;

		public UIObjectFactory(UIObjectManager _uiObjectManager)
		{
			uiObjectManager = _uiObjectManager;
		}
		public Button CreateButton(double x, double y, int width, int height, string text = "",ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black, string textAlign = "TL", UIEventHandler? command = null)
		{
			Button newButton = new Button(x,y,width,height,text,foregroundColor,backgroundColor,textAlign ,command);
			uiObjectManager.AddObject(newButton);
			return newButton;
		}
	}
}

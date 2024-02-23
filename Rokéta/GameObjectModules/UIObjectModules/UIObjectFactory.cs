using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses;
using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.ButtonModules;
using Rokéta.Statics;
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
		public Button CreateButton(double x, double y, int width, int height,int padding = 0, string text = "", 
			ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black,
			string textHorizontalAlign = Defaults.UI.HorizontalAlign, string textVerticalAlign = Defaults.UI.VerticalAlign, UIEventHandler? command = null)
		{
			return CreateButton(x, y, width, height,padding,padding,padding,padding, text, foreground, background, textHorizontalAlign,textVerticalAlign, command);
		}
		public Button CreateButton(double x, double y, int width, int height, int padx, int pady, string text = "", 
			ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black,string textHorizontalAlign = Defaults.UI.HorizontalAlign, 
			string textVerticalAlign = Defaults.UI.VerticalAlign, UIEventHandler? command = null)
		{
			return CreateButton(x, y, width, height,pady,padx,pady,padx, text, foreground, background, textHorizontalAlign,textVerticalAlign, command);
		}
		public Button CreateButton(double x, double y, int width, int height, int padTop, int padRight, int padBot, int padLeft, string text = "", 
			ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black, string textHorizontalAlign = Defaults.UI.HorizontalAlign,
			string textVerticalAlign = Defaults.UI.VerticalAlign, UIEventHandler? command = null)
		{
			Button newButton = new Button(x, y, width, height, text, foreground, background, new Padding(padTop, padRight, padBot, padLeft), textHorizontalAlign,textVerticalAlign, command);
			uiObjectManager.AddObject(newButton);
			return newButton;
		}
	}
}

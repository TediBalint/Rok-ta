using Rokéta.Statics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses
{
	public class Button : UIObject
	{
		private string text;
		public Button(double x, double y,int width, int height, string _text,ConsoleColor textColor, UIEventHandler command = null) : base(x, y, 5, width, height, null)
		{
			text = _text;
			if (command != null)
			{
				OnEnter += command;
			}
		}
		
	}
}

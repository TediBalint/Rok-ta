using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.GameObjectModules.UIObjectModules.UIEventArgs;
using System;

namespace Rokéta.GameObjectModules.UIObjectModules
{
	public abstract class UIObject : GameObject
	{
		public bool IsFocused { get; set; } = false;

		public delegate void UIEventHandler(object sender);
		public delegate void UIKeyEventHandler(object sender, UIKeyEventArgs e);

		public event UIEventHandler OnEnter;
		public event UIEventHandler OnChanged;
		public event UIEventHandler OnFocus;
		public event UIEventHandler OnBlur;
		public event UIKeyEventHandler OnKeyDown;

		public UIObject(double x, double y, int zIndex, int? width, int? height, string? filePath) : base (x,y,zIndex,width,height,filePath) 
		{
			
		}
		public void Enter()
		{
			OnEnter?.Invoke(this);
		}
		public void Change() 
		{ 
			OnChanged?.Invoke(this);
		}
		public void Focus()
		{
			IsFocused = true;
			OnFocus?.Invoke(this);
		}
		public void Blur()
		{
			IsFocused = false;
			OnBlur?.Invoke(this);
		}
		public void KeyDown(ConsoleKey consoleKey)
		{
			OnKeyDown?.Invoke(this, new UIKeyEventArgs { ConsoleKey = consoleKey });
		}
	}
}

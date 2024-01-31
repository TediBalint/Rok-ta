using System;

namespace Rokéta.GameObjectModules.UIObjectModules
{
	public abstract class UIObject : GameObject
	{
		public bool IsFocused { get; set; } = false;

		public delegate void UIEvent(object sender);

		public event UIEvent OnEnter;
		public event UIEvent OnChanged;
		public event UIEvent OnFocus;
		public event UIEvent OnBlur;

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
	}
}

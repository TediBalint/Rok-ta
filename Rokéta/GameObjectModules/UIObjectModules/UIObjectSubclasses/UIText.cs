using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates;
using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.StartCordStrategys;
using System.Diagnostics;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses
{
	public abstract class UIText : UIObject
	{

		
		protected TextStateContext textStateContext;

		protected string text;
		public string Text
		{
			get => text;
			set
			{
				text = value[..Width];
				updateText();
			}
		}
		protected string textHorizontalAlignState
		{
			get => textHorizontalAlignState;
			set => textHorizontalAlignState = value.ToUpper();
		}
		public string TextHorizontalAlignState { 
			get => textHorizontalAlignState; 
			set
			{
				textHorizontalAlignState = value.ToUpper();
				textStateContext.SetTextState(textHorizontalAlignState);
				updateText();
			}
		}
		protected string textVerticalAlignStrategy
		{
			get => textVerticalAlignStrategy;
			set => textVerticalAlignStrategy = value.ToUpper();
		}
		public string TextVerticalAlignStrategy
		{
			get => textVerticalAlignStrategy;
			set
			{
				textVerticalAlignStrategy = value.ToUpper();
				textStateContext.SetTextState(textVerticalAlignStrategy);
				updateText();
			}
		}
		protected ConsoleColor foregroundColor;
		public ConsoleColor ForegroundColor
		{
			get => foregroundColor;
			set
			{
				foregroundColor = value;
				updateText();
			}
		}
		protected ConsoleColor backgroundColor;
		public ConsoleColor BackgroundColor
		{
			get => backgroundColor;
			set
			{
				backgroundColor = value;
				updateText();
			}
		}
		public Padding Padding;
		public UIText(double x, double y, int width, int height, string _text, ConsoleColor _foregroundColor, ConsoleColor _backgroundColor, string _textHorizontalAlign,string _textVerticalAlign, Padding _padding)
			: base(x, y, 5, width, height, null)
		{

			text = _text;
			foregroundColor = _foregroundColor;
			backgroundColor = _backgroundColor;
			textHorizontalAlignState = _textHorizontalAlign;
			textVerticalAlignStrategy = _textVerticalAlign;
			textStateContext = new TextStateContext(textHorizontalAlignState, textVerticalAlignStrategy);
			Padding = _padding;
			Padding.PaddingChanged += updateText;
			updateText();
		}
		protected void updateText()
		{
			textStateContext.UpdateText(ref CharInfos, text, foregroundColor, backgroundColor, Padding);
		}
		private void updateText(object? sender, EventArgs e)
		{
			updateText();
		}
	}
}

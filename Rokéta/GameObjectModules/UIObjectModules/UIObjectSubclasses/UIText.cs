using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates;
using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.LeftTextStates;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses
{
	public abstract class UIText : UIObject
	{
		private readonly Dictionary<string, TextState> textStates = new Dictionary<string, TextState>()
		{
			{"TL",new TLTextState()},
			{"CL", new CLTextState()}
		};
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
		protected string textAlignState;
		public string TextAlignState { 
			get => textAlignState; 
			set
			{
				if (textStates.ContainsKey(value))
				{
					textAlignState = value;
					textStateContext.SetTextUpdateStrategy(textStates[value]);
					updateText();
				}
				else Debug.WriteLine($"UIText.cs//TextAlignState Setter: {value} state doesn't exist");
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
		
		protected int marginX;
		public int MarginX
		{
			get => marginX;
			set
			{
				marginX = value;
				updateText();
			}
		}
		protected int marginY;
		public int MarginY
		{
			get => marginY;
			set
			{
				marginY = value;
				updateText();
			}
		}
		public Padding Padding;
		public UIText(double x, double y, int width, int height, string _text, ConsoleColor _foregroundColor, ConsoleColor _backgroundColor, string _textAlign, Padding _padding)
			: base(x, y, 5, width, height, null)
		{
			textAlignState = _textAlign;
			text = _text;
			foregroundColor = _foregroundColor;
			backgroundColor = _backgroundColor;
			textAlignState = _textAlign;
			textStateContext = new TextStateContext(textStates[textAlignState]);
			Padding = _padding;
			Padding.MarginChanged += updateText;
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

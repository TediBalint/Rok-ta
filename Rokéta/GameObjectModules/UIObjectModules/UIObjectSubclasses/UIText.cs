using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses
{
	public class UIText : UIObject
	{
		private readonly Dictionary<string, ITextState> textStates = new Dictionary<string, ITextState>()
		{
			{"TL",new TLTextState()}
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

		public UIText(double x, double y, int width, int height, string _text, ConsoleColor _foregroundColor, ConsoleColor _backgroundColor, string _textAlign = "CC") : base(x, y, 5, width, height, null)
		{
			textAlignState = _textAlign;
			text = _text;
		}
		private void updateText()
		{
			textStateContext.UpdateText(ref CharInfos, text, foregroundColor, backgroundColor);
		}
		
	}
}

using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.StartCordStrategys;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
    public class TextStateContext
    {
        private TextState textState;
        private IStartCordStrategy startCordStrategy;

        private readonly Dictionary<string, IStartCordStrategy> cordStrategies = new Dictionary<string, IStartCordStrategy>()
        {
            {"TOP", new TopStrategy() },
            {"MIDDLE", new MiddleStrategy() },
            {"BOTTOM", new BottomStrategy()}
        };
		private readonly Dictionary<string, TextState> textStates = new Dictionary<string, TextState>()
		{
			{"LEFT",new LeftTextState() },
			{"CENTER", new CenterTextState()},
			{"RIGHT", new RightTextState()}
		};
		public TextStateContext(string _textHorizontalState, string _cordVerticalStrategy)
        {
            SetTextState(_textHorizontalState);
            SetStartCordStrategy(_cordVerticalStrategy);
        }
        public void UpdateText(ref CharInfo?[,] pixels,string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, Padding padding)
        {
            textState.UpdateText(ref pixels, text, foregroundColor, backgroundColor, padding, startCordStrategy);
		}
        public void SetTextState(string _textState) => textState = textStates[_textState];
        public void SetStartCordStrategy(string _startCordStrategy) => startCordStrategy = cordStrategies[_startCordStrategy]; 
     }
}

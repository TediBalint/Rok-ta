namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
    public class TextStateContext
    {
        
        private TextState textState;
        public TextStateContext(TextState _textState)
        {
            textState = _textState;
        }
        public void UpdateText(ref CharInfo?[,] pixels,string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor, int marginX, int marginY)
        {
            textState.UpdateText(ref pixels, text, foregroundColor, backgroundColor, marginX, marginY);
		}
        public void SetTextUpdateStrategy(TextState textUpdateStrategy) => textState = textUpdateStrategy;
    }
}

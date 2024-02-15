namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates
{
    public class TextStateContext
    {
        
        private ITextState textState;
        public TextStateContext(ITextState _textState)
        {
            textState = _textState;
        }
        public void UpdateText(ref CharInfo?[,] pixels,string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            textState.UpdateText(ref pixels, text, foregroundColor, backgroundColor);
		}
        public void SetTextUpdateStrategy(ITextState textUpdateStrategy) => textState = textUpdateStrategy;
    }
}

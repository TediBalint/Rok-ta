namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.ButtonModules
{
    public class Button : UIText
    {
        
        public Button(double x, double y, int width, int height, string _text, ConsoleColor foregroundColor,ConsoleColor backgroundColor, 
            Padding padding, string _textHorizontalAlign = "LEFT",string _textVerticalAlign = "TOP", UIEventHandler? command = null) :
            base(x, y, width, height, _text, foregroundColor,backgroundColor, _textHorizontalAlign, _textVerticalAlign, padding)
        {
            if (command != null)
            {
                OnEnter += command;
            }
        }
        
    }
}

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.ButtonModules
{
    public class Button : UIText
    {
        
        public Button(double x, double y, int width, int height, string _text, ConsoleColor foregroundColor,ConsoleColor backgroundColor, string _textAlign = "TL",int _marginX = 0, int margin_Y = 0,UIEventHandler? command = null) : base(x, y, width, height, _text, foregroundColor,backgroundColor, _textAlign, _marginX, margin_Y)
        {
            if (command != null)
            {
                OnEnter += command;
            }
        }
        
    }
}

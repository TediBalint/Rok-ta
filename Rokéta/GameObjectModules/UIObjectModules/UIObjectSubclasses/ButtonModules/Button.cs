namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.ButtonModules
{
    public class Button : UIText
    {
        
        public Button(double x, double y, int width, int height, string _text, ConsoleColor foregroundColor,ConsoleColor backgroundColor, UIEventHandler? command = null) : base(x, y, width, height, _text, foregroundColor,backgroundColor)
        {
            if (command != null)
            {
                OnEnter += command;
            }
        }
        
    }
}

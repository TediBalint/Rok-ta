namespace Rokéta.GameObjectModules.UIObjectModules
{
	public class ActiveObjectContext
	{
		private ActiveObjectStrategy currStrategy;	
		public ActiveObjectContext(ActiveObjectStrategy defaultStrategy)
		{
			currStrategy = defaultStrategy;
		}
		public ActiveObjectContext() 
		{
			return;
		}
		public void SetStrategy(ActiveObjectStrategy activeObjectStrategy)
		{
			currStrategy = activeObjectStrategy;
		}
		public UIObject GetActiveGameObject(List<UIObject> uiObjects, Stack<UIObject> lastObjects)
		{
			return currStrategy.GetActive(uiObjects, lastObjects);
		}
	}
}

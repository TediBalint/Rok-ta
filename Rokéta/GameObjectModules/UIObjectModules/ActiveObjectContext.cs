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
		public UIObject GetActiveGameObject(List<UIObject> uiObjects, UIObject currentObject)
		{
			return currStrategy.GetActive(uiObjects, currentObject);
		}
	}
}

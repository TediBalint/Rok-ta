using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.UIObjectModules
{
	public class ActiveObjectContext
	{
		private IActiveObjectStrategy currStrategy;	
		public ActiveObjectContext(IActiveObjectStrategy defaultStrategy)
		{
			currStrategy = defaultStrategy;
		}
		public void SetStrategy(IActiveObjectStrategy activeObjectStrategy)
		{
			currStrategy = activeObjectStrategy;
		}
		public UIObject GetActiveGameObject(List<UIObject> uiObjects, UIObject currentObject)
		{
			return currStrategy.GetActive(uiObjects, currentObject);
		} 
	}
}

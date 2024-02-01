using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.UIObjectModules
{
	public interface IActiveObjectStrategy
	{
		UIObject GetActive(List<UIObject> uiObjects, UIObject activeObject);
	}
}

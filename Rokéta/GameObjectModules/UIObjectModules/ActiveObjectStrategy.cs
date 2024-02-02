namespace Rokéta.GameObjectModules.UIObjectModules
{
	public abstract class ActiveObjectStrategy
	{
		public abstract UIObject GetActive(List<UIObject> uiObjects, UIObject activeObject);
		protected List<UIObject> GetXOverlapping(List<UIObject> uiObjects, UIObject activeObject, int offset)
		{
			List<UIObject> overlappingXObjects = new List<UIObject>();
			for (int i = 0; i < uiObjects.Count; i++)
			{
				UIObject currUIObject = uiObjects[i];
				if (currUIObject.IsXOverlapping(activeObject, offset)) overlappingXObjects.Add(currUIObject);
			}
			return overlappingXObjects;
		}
		protected List<UIObject> GetYOverlapping(List<UIObject> uiObjects, UIObject activeObject, int offset, bool checkLeftCondition)
		{
			List<UIObject> overlappingYObjects = new List<UIObject>();
			for (int i = 0; i < uiObjects.Count; i++)
			{
				UIObject currUIObject = uiObjects[i];
				if(currUIObject.IsYOverlapping(activeObject, offset)) overlappingYObjects.Add(currUIObject);
			}
			return overlappingYObjects;
		}
	}
}

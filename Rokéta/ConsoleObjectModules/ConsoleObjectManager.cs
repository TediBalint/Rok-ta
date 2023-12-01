using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Roketa.ConsoleObjectModules
{
    internal class ConsoleObjectManager
	{
		public List<ConsoleObject> consoleObjectList;
		public CharInfo[,] pixels;
		public ConsoleObjectManager(int width, int height)
		{
			consoleObjectList = new List<ConsoleObject>();
			pixels = new CharInfo[height, width];
		}
		public void HandleCollisions()
		{
			foreach (ConsoleObject consoleObj in consoleObjectList) 
			{
				foreach(ConsoleObject otherObject in consoleObjectList)
				{
					if(consoleObj.isCollision(otherObject))
					{
						consoleObj.OnCollision(otherObject);
					}
				}
			}
		}
		//public ConsoleObject CreateConsoleObject(int x, int y, int zIndex, int width, int height, string? filePath = null, bool instantlyShow = true)
		//{
		//	ConsoleObject newObj = new ConsoleObject(x, y, zIndex, width, height, filePath);
		//	consoleObjectList.Insert(findConsoleObjectPlace(newObj), newObj);
		//	if (instantlyShow)
		//	{
		//		newObj.insertToMatrix(ref pixels);
		//	}
		//	return newObj;
		//}
		
		public void RenderObjects()
		{
            foreach (ConsoleObject consoleObject in consoleObjectList)
            {
				consoleObject.insertToMatrix(ref pixels);
            }
        }
		
	}
}

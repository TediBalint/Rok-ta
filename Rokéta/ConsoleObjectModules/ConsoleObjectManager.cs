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
		
		public void RenderObjects()
		{
			for (int i = 0; i < consoleObjectList.Count; i++)
			{
				ConsoleObject consoleObject = consoleObjectList[i];
				if (consoleObject.IsDisposed)
				{
					consoleObjectList.Remove(consoleObject);
				}
				else
				{
					consoleObject.insertToMatrix(ref pixels);
				}
			}
        }
		
		
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roketa.ConsoleObject
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

		public ConsoleObject BuildConsoleObject(int x, int y, int zIndex, int width, int height, string? filePath = null, bool instantlyShow = true)
		{
			ConsoleObject newObj = new ConsoleObject(x, y, zIndex, width, height, filePath);
			consoleObjectList.Insert(findConsoleObjectPlace(newObj), newObj);
			if(instantlyShow)
			{
				newObj.insertToMatrix(ref pixels);
			}
			return newObj;
		}
		public void RenderObjects()
		{
            foreach (ConsoleObject consoleObject in consoleObjectList)
            {
				consoleObject.insertToMatrix(ref pixels);
            }
        }
		private int findConsoleObjectPlace(ConsoleObject consoleObj)
		{
			int len = consoleObjectList.Count;
			int thisIndex = consoleObj.Z_Index;
			//szelsoesetek
			if (len == 0)
			{
				return 0;
			}
			if (thisIndex >= consoleObjectList.Max(x => x.Z_Index))
			{
				return len;
			}
			if (thisIndex <= consoleObjectList.Min(x => x.Z_Index))
			{
				return 0;
			}

			int left = 0;
			int right = len - 1;
			while (left < right)
			{
				int middle = (left + right) / 2;
				if (consoleObjectList[middle].Z_Index <= thisIndex && consoleObjectList[middle + 1].Z_Index >= thisIndex)
				{
					return middle+1;
				}
				else if (consoleObjectList[middle].Z_Index <= thisIndex)
				{
					left = middle + 1;
				}
				else if (consoleObjectList[middle].Z_Index <= thisIndex)
				{
					right = middle - 1;
				}
			}
			return len;
		}
	}
}

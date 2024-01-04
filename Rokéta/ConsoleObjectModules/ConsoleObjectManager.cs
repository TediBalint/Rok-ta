using Rokéta.ConsoleObjectModules;
using Rokéta.Statics;
using System.Diagnostics;

namespace Roketa.ConsoleObjectModules
{
    public class ConsoleObjectManager
	{
		// ConsoleObjectList sorted by Zindex for render
		public string saveFilePath;
		public List<ConsoleObject> consoleObjectList;

		public CharInfo[,] pixels;
		public ConsoleObjectManager(int width, int height, string _savefilepath)
		{
			saveFilePath = _savefilepath;
			consoleObjectList = new List<ConsoleObject>();
			pixels = new CharInfo[height, width];
		}
		public void HandleCollisions()
		{
			for (int i = 0; i < consoleObjectList.Count; i++)
			{
				for (int j = 0; j < consoleObjectList.Count; j++)
				{
					if (i != j)
					{
						ConsoleObject consoleObj = consoleObjectList[i];
						ConsoleObject otherObject = consoleObjectList[j];
						if(consoleObj.isCollision(otherObject))
						{
							consoleObj.OnCollision(otherObject);
						}
					}
				}
			}
		}
		public void SaveGameState()
		{
			using (StreamWriter sw = new StreamWriter(saveFilePath, false))
			{
				sw.WriteLine(Encrypter.Encrypt($"{Globals.isMusicEnabled};{Globals.isGameSoundEnabled};{Globals.kills};{Globals.lastHealthBonus}"));
                foreach (ConsoleObject obj in consoleObjectList)
                {
					obj.SaveToFile(sw);
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

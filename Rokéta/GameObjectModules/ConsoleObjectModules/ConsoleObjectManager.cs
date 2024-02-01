using Rokéta.ConsoleObjectModules;
using Rokéta.Statics;
using System.Diagnostics;

namespace Rokéta.GameObjectModules.ConsoleObjectModules
{
    public class ConsoleObjectManager
    {
        // ConsoleObjectList sorted by Zindex for render
        public string SaveFilePath;
        public List<ConsoleObject> ConsoleObjects;

        public CharInfo[,] Pixels;
        public ConsoleObjectManager(int width, int height, string _savefilepath)
        {
            SaveFilePath = _savefilepath;
            ConsoleObjects = new List<ConsoleObject>();
            Pixels = new CharInfo[height, width];
        }
        public void HandleCollisions()
        {
            for (int i = 0; i < ConsoleObjects.Count; i++)
            {
                for (int j = 0; j < ConsoleObjects.Count; j++)
                {
                    if (i != j)
                    {
                        ConsoleObject consoleObj = ConsoleObjects[i];
                        ConsoleObject otherObject = ConsoleObjects[j];
                        if (consoleObj.IsCollision(otherObject))
                        {
                            consoleObj.OnCollision(otherObject);
                        }
                    }
                }
            }
        }
		public void UpdateObjects()
		{
			for (int i = 0; i < ConsoleObjects.Count; i++)
			{
				ConsoleObject consoleObject = ConsoleObjects[i];
				if (consoleObject.IsDisposed)
				{
					ConsoleObjects.Remove(consoleObject);
				}
				else
				{
					consoleObject.Update(ref Pixels);
				}

                // Collision Detection
				for (int j = 0; j < ConsoleObjects.Count; j++)
				{
					if (i != j)
					{
						ConsoleObject otherObject = ConsoleObjects[j];
						if (consoleObject.IsCollision(otherObject))
						{
							consoleObject.OnCollision(otherObject);
						}
					}
				}
				
				
			}
		}
		public void SaveGameState()
        {
            using (StreamWriter sw = new StreamWriter(SaveFilePath, false))
            {
                sw.WriteLine(Encrypter.Encrypt($"{Globals.isMusicEnabled};{Globals.isGameSoundEnabled};{Globals.kills};{Globals.lastHealthBonus}"));
                foreach (ConsoleObject obj in ConsoleObjects)
                {
                    obj.SaveToFile(sw);
                }
            }
        }

    }
}

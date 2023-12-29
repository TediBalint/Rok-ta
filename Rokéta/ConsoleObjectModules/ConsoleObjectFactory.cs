using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.Statics;
using System.Diagnostics;
using System.Text;

namespace Rokéta.ConsoleObjectModules
{
	public class ConsoleObjectFactory
	{
		private ConsoleObjectManager ConsoleObjectManager { get; set; }
		public bool loadedGameState = false;

		public ConsoleObjectFactory(ConsoleObjectManager consoleObjectManager)
		{
			ConsoleObjectManager = consoleObjectManager;
		}
		public Player loadGameState(Player player)
		{
			string filePath = ConsoleObjectManager.saveFilePath;
			ConsoleObjectManager.consoleObjectList.Clear();
			if (File.Exists(filePath))
			{
				loadedGameState = true;
				using (StreamReader reader = new StreamReader(filePath))
				{
					string[] firstLine = Encrypter.Decrypt(reader.ReadLine()).Split(';');
					Globals.isMusicEnabled = bool.Parse(firstLine[0]);
					Globals.isGameSoundEnabled = bool.Parse(firstLine[1]);
					Globals.kills = int.Parse(firstLine[2]);
					Globals.enemyCount = int.Parse(firstLine[3]);
					Globals.lastHealthBonus = double.Parse(firstLine[4]);
					while (!reader.EndOfStream)
					{

						string[] line = Encrypter.Decrypt(reader.ReadLine()).Split(';');
						foreach (string elem in line)
						{
							Debug.WriteLine(elem);
						}
						string ObjType = line[0];
						double Objx = double.Parse(line[1]);
						double Objy = double.Parse(line[2]);
						int ObjzIndex = int.Parse(line[3]);
						int Objwidth = int.Parse(line[4]);
						int Objheight = int.Parse(line[5]);
						string ObjFilePath = line[6];
						if (ObjType == "Player")
						{
							player = CreatePlayer(Objx, Objy, ObjzIndex, Objwidth, Objheight, ObjFilePath);
						}
						else if (ObjType == "Enemy")
						{
							double[] velocity = new double[] { double.Parse(line[7]), double.Parse(line[8]) };
							double health = double.Parse(line[9]);
							CreateEnemy(Objx, Objy, ObjzIndex, Objwidth, Objheight, ObjFilePath, velocity, health);
						}
						else if (ObjType == "Background")
						{
							CreateBackground(filePath: ObjFilePath);
						}
						else
						{
							Debug.WriteLine($"Error in ConsoleObjectFactory.cs: {ObjType} unkown!");
						}

						//return $"{GetType().Name};{X};{Y};{Z_Index};{Width};{Height};{FilePath}";
					}
				}
			}
			else
			{
				Debug.WriteLine($"Error in ConsoleObjectFactory:\n{filePath} not found!");
			}
			return player;



		}
		public Player CreatePlayer(double x, double y, int zIndex, int width, int height, string? filePath = null)
		{
			Player newPlayer = new Player(x, y, zIndex, width, height, filePath);
			ConsoleObjectManager.consoleObjectList.Insert(findConsoleObjectPlace(newPlayer), newPlayer);	
			return newPlayer;
		}
		public Enemy CreateEnemy(double x, double y, int zIndex, int? width, int? height, string? filePath, double[] velocity, double health)
		{
			Globals.enemyCount++;
			Enemy newEnemy = new Enemy(x,y,zIndex, width, height, filePath, velocity, health);
			ConsoleObjectManager.consoleObjectList.Insert(findConsoleObjectPlace(newEnemy), newEnemy);            
			return newEnemy;
        }
		public void AddBullet(Bullet bullet, double angle, double[] spawnPos)
		{
			Bullet newBullet = bullet.DeepCopy();
			newBullet.angle = angle;
			newBullet.X = spawnPos[0];
			newBullet.Y = spawnPos[1];
			ConsoleObjectManager.consoleObjectList.Insert(findConsoleObjectPlace(newBullet), newBullet);
		}
		public Background CreateBackground(ConsoleColor? color = null, string? filePath = null)
		{
			Background newBackgrond = new Background(color, filePath);
			ConsoleObjectManager.consoleObjectList.Insert(findConsoleObjectPlace(newBackgrond), newBackgrond);
			newBackgrond.insertToMatrix(ref ConsoleObjectManager.pixels);
			return newBackgrond;
		}
		private int findConsoleObjectPlace(ConsoleObject consoleObj)
		{
			int len = ConsoleObjectManager.consoleObjectList.Count;
			int thisIndex = consoleObj.Z_Index;
			//szelsoesetek
			if (len == 0)
			{
				return 0;
			}
			if (thisIndex >= ConsoleObjectManager.consoleObjectList.Last().Z_Index)
			{
				return len;
			}
			if (thisIndex <= ConsoleObjectManager.consoleObjectList.First().Z_Index)
			{
				return 0;
			}

			int left = 0;
			int right = len - 1;
			while (left < right)
			{
				int middle = (left + right) / 2;
				if (ConsoleObjectManager.consoleObjectList[middle].Z_Index <= thisIndex && ConsoleObjectManager.consoleObjectList[middle + 1].Z_Index >= thisIndex)
				{
					return middle + 1;
				}
				else if (ConsoleObjectManager.consoleObjectList[middle].Z_Index <= thisIndex)
				{
					left = middle + 1;
				}
				else if (ConsoleObjectManager.consoleObjectList[middle].Z_Index <= thisIndex)
				{
					right = middle - 1;
				}
			}
			return len;
		}
	}
}

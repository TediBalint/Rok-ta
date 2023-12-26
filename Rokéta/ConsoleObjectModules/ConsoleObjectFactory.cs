using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Rokéta.ConsoleObjectModules
{
	public class ConsoleObjectFactory
	{
		private ConsoleObjectManager ConsoleObjectManager { get; set; }

		public ConsoleObjectFactory(ConsoleObjectManager consoleObjectManager)
		{
			ConsoleObjectManager = consoleObjectManager;
		}
		public Player CreatePlayer(int x, int y, int zIndex, int width, int height, Weapon weapon, string? filePath = null, bool instantlyShow = true)
		{
			Player newPlayer = new Player(x, y, zIndex, width, height, filePath, weapon);
			ConsoleObjectManager.consoleObjectList.Insert(findConsoleObjectPlace(newPlayer), newPlayer);
			if (instantlyShow)
			{
				newPlayer.insertToMatrix(ref ConsoleObjectManager.pixels);
			}
			return newPlayer;
		}
		public Enemy CreateEnemy(int x, int y, int zIndex, int? width, int? height, string? filePath, bool instantlyShow = true)
		{
			Enemy newEnemy = new Enemy(x,y,zIndex, width, height, filePath);
			ConsoleObjectManager.consoleObjectList.Insert(findConsoleObjectPlace(newEnemy), newEnemy);
            if (instantlyShow)
            {
				newEnemy.insertToMatrix(ref ConsoleObjectManager.pixels);
            }
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

using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules.EnemyGenModules
{
	public class PosGenQuick : IPosGenStrategy
	{
		Random random = new Random();
		public double GetX(Enemy enemy, Player player)
		{
			double x;
			if (enemy.Width >= (int)(player.X - player.Width - enemy.Width / 2)) x = random.Next((int)(player.X + player.Width + enemy.Width / 2), Console.WindowWidth - enemy.Width);
			else if ((int)(player.X + player.Width * 2 + enemy.Width / 2) >= Console.WindowWidth - enemy.Width) x = random.Next(enemy.Width, (int)(player.X - player.Width * 2 - enemy.Width / 2));
			else
			{
				x = new double[] {
					random.Next(enemy.Width, (int)(player.X-player.Width - enemy.Width/2)),
					random.Next((int)(player.X + player.Width * 2 + enemy.Width/2), Console.WindowWidth - enemy.Width)}[random.Next(0, 2)];
			}
			return x;
		}
		public double GetY(Enemy enemy)
		{
			return random.Next(enemy.Height, Console.WindowHeight - enemy.Height);
			//double y;
			//if (enemy.Height >= (int)(player.Y - player.Height - enemy.Height / 2)) y = random.Next((int)(player.Y + player.Height + enemy.Height / 2), Console.WindowHeight - enemy.Height);
			//else if ((int)(player.Y + player.Height + enemy.Height / 2) >= Console.WindowHeight - enemy.Height) y = random.Next(enemy.Height, (int)(player.Y - player.Height - enemy.Height / 2));
			//else
			//{
			//	y = new double[] {
			//	random.Next(enemy.Height, (int)(player.Y - player.Height - enemy.Height/2)),
			//	random.Next((int)(player.Y + player.Height + enemy.Height/2), Console.WindowHeight - enemy.Height)}[random.Next(0, 2)];
			//}
			//return y;
		}
	}
}

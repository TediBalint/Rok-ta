using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.Statics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules
{
	public class EnemyGenerator
	{
		private Random random = new Random();
		private Player player;
		private ConsoleObjectFactory consoleObjectFactory;
		private Stopwatch stopwatch;
		public EnemyGenerator(ConsoleObjectFactory _consoleObjectFactory, Player _player) 
		{ 
			player = _player;
			stopwatch = new Stopwatch();
			stopwatch.Start();
			consoleObjectFactory = _consoleObjectFactory;
		}
		public void Generate()
		{
			if(stopwatch.Elapsed.Seconds > getTimeUntilNextGen())
			{
				GenerateEnemy();
				stopwatch.Restart();
			}
		}
		private double getTimeUntilNextGen()
		{
			double pow = 10;
			if (Globals.kills > 1100) pow = 1000;
			if (Globals.kills < 110) pow = 100;
			else if (Globals.kills < 15) pow = 10;

			if (Globals.kills < 1600)
			{
				
				return 0.1 + Math.Min(1 / Math.Pow(2, Globals.kills / pow), 5) + Math.Min((Globals.enemyCount / Globals.kills * 100), 3);
			}
			else if(Globals.kills < 1610)
			{
				if (Globals.enemyCount > 0) return double.PositiveInfinity; 
				else return 0;
			}
			else
			{
				return Math.Min(1 / Math.Pow(2, Globals.kills / pow), 5) + Math.Min((Globals.enemyCount / Globals.kills * 100), 3);
			}
		}
		private void GenerateEnemy()
		{
			Globals.lastHealthBonus += random.NextDouble() * Globals.kills/100;	
			Enemy enemy = GetEnemy();
			double x = new double[] {
				random.Next(0, (int)(player.X-player.Width - enemy.Width/2)), random.Next((int)(player.X + player.Width + enemy.Width/2),
				Console.WindowWidth - enemy.Width)}[random.Next(0,2)];
			double y = new double[] {
				random.Next(0, (int)(player.Y - player.Height - enemy.Height/2)), 
				random.Next(Math.Min((int)(player.Y + player.Height + enemy.Height/2), Console.WindowHeight - enemy.Height-1), Console.WindowHeight - enemy.Height)}[random.Next(0, 2)];

			double[] velocity = new double[] { 3 + (random.NextDouble() * Globals.kills / 100), 3 + (random.NextDouble() * Globals.kills / 100) };
			for(int i = 0; i < velocity.Length; i++) velocity[i] *= Math.Sign(random.Next(-1,1)+0.1);
			Debug.WriteLine(velocity[0] + " " + velocity[1]);
			if (Globals.kills > 2000) enemy.Health = 50000;
			double health = enemy.Health + Globals.lastHealthBonus;
			consoleObjectFactory.CreateEnemy(x,y, enemy.Z_Index, enemy.Width, enemy.Height,enemy.FilePath, velocity, health);
		}
		private Enemy GetEnemy()
		{
			foreach (int killCount in Defaults.enemies.Keys)
			{
				if(Globals.kills >= killCount) return Defaults.enemies[killCount][random.Next(0, Defaults.enemies[killCount].Length)];
			}
			return Defaults.enemies.Last().Value.Last();
		}
	}
}

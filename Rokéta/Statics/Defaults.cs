using Rokéta.ConsoleObjectModules.AnimationModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.Statics
{
	public static class Defaults
	{
		public static List<Bullet> bullets = new List<Bullet>() 
		{
			new Bullet(0,0,2,1,1,"SaveFiles\\Objects\\Bullets\\Bullet1.txt", 10, 1, 1, false),
			new Bullet(0,0,2,2,1,"SaveFiles\\Objects\\Bullets\\Bullet2.txt", 15, 5, 1, false),
			new Bullet(0,0,2,2,2,"SaveFiles\\Objects\\Bullets\\Bullet3.txt", 15, 15, 1, false),
			new Bullet(0,0,2,3,2,"SaveFiles\\Objects\\Bullets\\Bullet4.txt", 20, 15, 2, false),
			new Bullet(0,0,2,3,2,"SaveFiles\\Objects\\Bullets\\Bullet4.txt", 30, 40, 2, false),
			new Bullet(0,0,2,3,2,"SaveFiles\\Objects\\Bullets\\Bullet5.txt", 50, 100, 3, false),
			new Bullet(0,0,2,1,1,"SaveFiles\\Objects\\Bullets\\Bullet6.txt", 50, 30, 5, true),
			new Bullet(0,0,2,2,2,"SaveFiles\\Objects\\Bullets\\Bullet7.txt", 55, 30, 10, true),
			new Bullet(0,0,2,5,3,"SaveFiles\\Objects\\Bullets\\Bullet8.txt", 75, 150, 8, true),
			new Bullet(0,0,2,5,3,"SaveFiles\\Objects\\Bullets\\Bullet9.txt", 75, 300, 20, true),
			new Bullet(0,0,2,5,3,"SaveFiles\\Objects\\Bullets\\Bullet10.txt", 75, 500, 15, true),
			new Bullet(0,0,2,5,3,"SaveFiles\\Objects\\Bullets\\Bullet11.txt", 75, 1000, 20, true),
			new Bullet(0,0,2,1,2,"SaveFiles\\Objects\\Bullets\\Bullet12.txt", 100, 200, 1, false),
			new Bullet(0,0,2,2,3,"SaveFiles\\Objects\\Bullets\\Bullet13.txt", 60, 5000, 1, false),
			new Bullet(0,0,2,2,3,"SaveFiles\\Objects\\Bullets\\Bullet14.txt", 150, 10000, 3, false),
			new Bullet(0,0,2,3,3,"SaveFiles\\Objects\\Bullets\\Bullet15.txt", 150, 50000, 10, true),
		};

		// you get value weapon after you have key or more kills
		public static Dictionary<int, Weapon> weapons = new Dictionary<int, Weapon>()
		{
			{750, new Weapon(bullets[15], 90, 1, 6, new string[] {"ShootSound1", "ShootSound2", "ShootSound3"})},
			{700, new Weapon(bullets[14], 90, 150, 3, new string[] {"ShootSound1", "ShootSound2", "ShootSound3"})},
			{650, new Weapon(bullets[13], 90, 25, 1, new string[] {"ShootSound1", "ShootSound2", "ShootSound3"})},
			{600, new Weapon(bullets[12], 90, 100, 1, new string[] {"ShootSound1", "ShootSound2", "ShootSound3"})},
			{550, new Weapon(bullets[11], 360, 0.2, 50, new string[] {"ShootSound1", "ShootSound2", "ShootSound3"})},
			{500, new Weapon(bullets[10], 360, 0.5, 50, new string[] {"ShootSound1", "ShootSound2", "ShootSound3"})},
			{450, new Weapon(bullets[9], 180, 1, 25, new string[] {"ShootSound1", "ShootSound2", "ShootSound3"})},
			{400, new Weapon(bullets[8], 135, 2, 10, new string[] {"ShootSound9"})},
			{350, new Weapon(bullets[7], 135, 2, 6, new string[] {"ShootSound8"})},
			{300, new Weapon(bullets[6], 90, 2, 4, new string[] {"ShootSound7"})},
			{250, new Weapon(bullets[5], 90, 2, 4, new string[] {"ShootSound6"})},
			{200, new Weapon(bullets[4], 60, 5, 3, new string[] {"ShootSound5"})},
			{150, new Weapon(bullets[3], 45, 3, 3, new string[] {"ShootSound4"})},
			{100, new Weapon(bullets[2], 45, 2, 2, new string[] {"ShootSound3"})},
			{50, new Weapon(bullets[1], 45, 2, 2, new string[] {"ShootSound2"})},
			{0, new Weapon(bullets[0], 90, 2, 1, new string[] {"ShootSound1"})}
		};
		
		public static Dictionary<string, ConsoleKey[]> keyBinds = new Dictionary<string, ConsoleKey[]>() 
		{
			{"Shoot", new ConsoleKey[] { ConsoleKey.Spacebar} },
			{"Up", new ConsoleKey[] {ConsoleKey.UpArrow, ConsoleKey.W } },
			{"Left", new ConsoleKey[] {ConsoleKey.LeftArrow, ConsoleKey.A } },
			{"Right", new ConsoleKey[] {ConsoleKey.RightArrow, ConsoleKey.D } },
			{"Down", new ConsoleKey[] {ConsoleKey.DownArrow, ConsoleKey.S } },
			{"MusicToggle", new ConsoleKey[] { ConsoleKey.M } },
			{"GameSoundToggle", new ConsoleKey[] {ConsoleKey.N } },
			{"Save", new ConsoleKey[] {ConsoleKey.V} }

		};
		
	}
	
}

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
		public static string defaultBulletPath = "SaveFiles\\Objects\\Bullet1.txt";
		public static Bullet defaultBullet = new Bullet(0,0,1,5,5,defaultBulletPath, 10);
		public static Weapon defaultWeapon = new Weapon(defaultBullet, 90, 5, 5);
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

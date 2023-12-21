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
		public static string defaultBulletPath = "SafeFiles\\Objects\\Bullet1.txt";
		public static Bullet defaultBullet = new Bullet(0,0,1,5,5,defaultBulletPath, 10);
		public static Weapon defaultWeapon = new Weapon(defaultBullet, 90, 5, 5);
	}
}

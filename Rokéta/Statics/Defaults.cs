using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses;

namespace Rokéta.Statics
{
    public static class Defaults
	{
		public static double[] DefaultSpeed = new double[2] {1,1};
		public const string DefaultBoosterName = "Booster1.txt";
		public const string DefaultButtonPath = "SaveFiles\\Objects\\UI\\Buttons\\1.txt";
		public static List<Bullet> bullets = new List<Bullet>() 
		{
			new Bullet(0,0,2,1,1,"SaveFiles\\Objects\\Bullets\\Bullet1.txt", 10, 2, 1, false),
			new Bullet(0,0,2,2,1,"SaveFiles\\Objects\\Bullets\\Bullet2.txt", 15, 5, 1, false),
			new Bullet(0,0,2,2,2,"SaveFiles\\Objects\\Bullets\\Bullet3.txt", 15, 15, 1, false),
			new Bullet(0,0,2,3,2,"SaveFiles\\Objects\\Bullets\\Bullet4.txt", 20, 15, 2, false),
			new Bullet(0,0,2,3,2,"SaveFiles\\Objects\\Bullets\\Bullet4.txt", 30, 40, 2, false),
			new Bullet(0,0,2,3,2,"SaveFiles\\Objects\\Bullets\\Bullet5.txt", 50, 100, 3, false),
			new Bullet(0,0,2,1,1,"SaveFiles\\Objects\\Bullets\\Bullet6.txt", 50, 30, 5, true),
			new Bullet(0,0,2,2,2,"SaveFiles\\Objects\\Bullets\\Bullet7.txt", 55, 30, 10, true),
			new Bullet(0,0,2,5,3,"SaveFiles\\Objects\\Bullets\\Bullet8.txt", 75, 150, 8, true),
			new Bullet(0,0,2,5,3,"SaveFiles\\Objects\\Bullets\\Bullet9.txt", 75, 300, 10, true),
			new Bullet(0,0,2,5,3,"SaveFiles\\Objects\\Bullets\\Bullet10.txt", 75, 500, 10, true),
			new Bullet(0,0,2,5,3,"SaveFiles\\Objects\\Bullets\\Bullet11.txt", 75, 1000, 10, true),
			new Bullet(0,0,2,1,2,"SaveFiles\\Objects\\Bullets\\Bullet12.txt", 100, 200, 1, false),
			new Bullet(0,0,2,2,3,"SaveFiles\\Objects\\Bullets\\Bullet13.txt", 60, 5000, 1, false),
			new Bullet(0,0,2,2,3,"SaveFiles\\Objects\\Bullets\\Bullet14.txt", 200, 10000, 3, false),
			new Bullet(0,0,2,3,3,"SaveFiles\\Objects\\Bullets\\Bullet15.txt", 150, 50000, 10, true),
		};

		// you get value weapon after you have key or more kills
		public static Dictionary<int, Weapon> weapons = new Dictionary<int, Weapon>()
		{
			{2000, new Weapon(bullets[15], 90, 1, 6, new string[] {"ShootSound16"})},
			{1610, new Weapon(bullets[14], 90, 100, 3, new string[] {"ShootSound15"})},
			{1600, new Weapon(bullets[13], 90, 25, 1, new string[] {"ShootSound14"})},
			{1500, new Weapon(bullets[12], 90, 100, 1, new string[] {"ShootSound13"})},
			{1000, new Weapon(bullets[11], 360, 0.2, 50, new string[] {"ShootSound12"})},
			{750, new Weapon(bullets[10], 360, 0.5, 50, new string[] {"ShootSound11"})},
			{500, new Weapon(bullets[9], 180, 1, 25, new string[] {"ShootSound10"})},
			{400, new Weapon(bullets[8], 135, 2, 10, new string[] {"ShootSound9"})},
			{300, new Weapon(bullets[7], 135, 2, 6, new string[] {"ShootSound8"})},
			{200, new Weapon(bullets[6], 90, 2, 4, new string[] {"ShootSound7"})},
			{150, new Weapon(bullets[5], 90, 2, 4, new string[] {"ShootSound6"})},
			{100, new Weapon(bullets[4], 60, 5, 3, new string[] {"ShootSound5"})},
			{50, new Weapon(bullets[3], 45, 3, 3, new string[] {"ShootSound4"})},
			{30, new Weapon(bullets[2], 45, 2, 2, new string[] {"ShootSound3"})},
			{10, new Weapon(bullets[1], 45, 2, 2, new string[] {"ShootSound2"})},
			{0, new Weapon(bullets[0], 90, 2, 1, new string[] {"ShootSound1"})}
		};
		public static Dictionary<int, string> backgrounds = new Dictionary<int, string>()
		{
			{2000, "SaveFiles\\Objects\\Background\\bg6.txt" },
			{1000, "SaveFiles\\Objects\\Background\\bg5.txt" },
			{600, "SaveFiles\\Objects\\Background\\bg4.txt"},
			{200, "SaveFiles\\Objects\\Background\\bg3.txt"},
			{0, "SaveFiles\\Objects\\Background\\bg2.txt"}
			//{250, new Background(filePath: "SaveFiles\\Objects\\Background\\bg3.txt")},
			//{0, new Background(filePath: "SaveFiles\\Objects\\Background\\bg2.txt")}
		};
		private static List<Enemy> EnemyList = new List<Enemy>() 
		{
			new Enemy(0,0,2,3,4, "SaveFiles\\Objects\\Enemies\\Enemy1.txt", new double[]{0,0},5), // 0
			new Enemy(0,0,2,3,3, "SaveFiles\\Objects\\Enemies\\Enemy2.txt", new double[]{0,0},10), // 1
			new Enemy(0,0,2,3,3, "SaveFiles\\Objects\\Enemies\\Enemy3.txt", new double[]{0,0},10), // 2
			new Enemy(0,0,2,3,4, "SaveFiles\\Objects\\Enemies\\Enemy3.txt", new double[]{0,0},20), // 3
			new Enemy(0,0,2,3,4, "SaveFiles\\Objects\\Enemies\\Enemy4.txt", new double[]{0,0},50), // 4
			new Enemy(0,0,2,3,4, "SaveFiles\\Objects\\Enemies\\Enemy5.txt", new double[]{0,0},150), // 5
			new Enemy(0,0,2,3,4, "SaveFiles\\Objects\\Enemies\\Enemy6.txt", new double[]{0,0},300), // 6
			new Enemy(0,0,2,3,4, "SaveFiles\\Objects\\Enemies\\Enemy7.txt", new double[]{0,0},500), // 7
			new Enemy(0,0,2,3,4, "SaveFiles\\Objects\\Enemies\\Enemy8.txt", new double[]{0,0},1500), // 8
			new Enemy(0,0,2,3,4, "SaveFiles\\Objects\\Enemies\\Enemy9.txt", new double[]{0,0},3000), // 9
			new Enemy(0,0,2,3,4, "SaveFiles\\Objects\\Enemies\\Enemy10.txt", new double[]{0,0},10000), // 10
			new Enemy(0,0,2,3,4, "SaveFiles\\Objects\\Enemies\\Enemy11.txt", new double[]{0,0},50000), // 11
			new Enemy(0,0,2,3,4, "SaveFiles\\Objects\\Enemies\\Enemy12.txt", new double[]{0,0},100000), // 12
			new Enemy(0,0,2,3,4, "SaveFiles\\Objects\\Enemies\\Enemy13.txt", new double[]{0,0},130000), // 13
		};
		public static Dictionary<int, Enemy[]> enemies = new Dictionary<int, Enemy[]>()
		{
			{2000, EnemyList.ToArray() },
			{1900, new Enemy[]{EnemyList[12] } },
			{1610, new Enemy[]{EnemyList[10], EnemyList[11] } },
			{1600, new Enemy[]{EnemyList[11], EnemyList[12] } },
			{1500, new Enemy[]{EnemyList[8], EnemyList[9], EnemyList[10] } },
			{1000, new Enemy[]{EnemyList[7], EnemyList[8], EnemyList[9] } },
			{500, new Enemy[]{EnemyList[6], EnemyList[7], EnemyList[8] } },
			{300, new Enemy[]{EnemyList[5], EnemyList[6], EnemyList[7] } },
			{200, new Enemy[]{EnemyList[4], EnemyList[5], EnemyList[6] } },
			{150, new Enemy[]{EnemyList[3], EnemyList[4], EnemyList[5] } },
			{100, new Enemy[]{EnemyList[2], EnemyList[3], EnemyList[4] } },
			{50, new Enemy[]{EnemyList[1], EnemyList[2], EnemyList[3] } },
			{10, new Enemy[]{EnemyList[0], EnemyList[1], EnemyList[2] } },
			{0, new Enemy[]{EnemyList[0], EnemyList[1] } },
			
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
			{"Save", new ConsoleKey[] {ConsoleKey.V} },
			{"Load", new ConsoleKey[] {ConsoleKey.L } },
			{"Cheat", new ConsoleKey[] {ConsoleKey.C } },
			{"Restart", new ConsoleKey[] {ConsoleKey.R}}
		};
		
	}
	
}

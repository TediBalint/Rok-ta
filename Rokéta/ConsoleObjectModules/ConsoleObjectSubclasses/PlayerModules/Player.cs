using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
    public class Player : ConsoleObject
    {
        //public PlayerStats Stats { get; set; }
        public Weapon Weapon { get; set; }
        public string Name { get; private set; }
        private string savefilePath;
		
        public Player(double x, double y, int zIndex, int width, int height, string? filePath, string name, Weapon weapon)
        : base(x, y, zIndex, width, height, filePath)
        {
            Name = name;
            Weapon = weapon;
			Weapon.spawnPos = new double[2] { X + (Width - Weapon.Bullet.Width) / 2, Y - 2};
			savefilePath = $"SafeFiles\\Objects\\Players\\{name}.txt";
            //setStats();
        }
		public override void MoveRaw(double x, double y)
		{
			base.MoveRaw(x, y);
			Weapon.spawnPos = new double[2] { X + (Width - Weapon.Bullet.Width)/2, Y-2};
		}
		//private void setStats()
		//{
		//    string FilePath = savefilePath;
		//    if (!File.Exists(FilePath)) FilePath = $"SafeFiles\\Default\\defaultPlayer.txt";
		//    Stats = getStatsFromFile(FilePath);
		//}
		//private PlayerStats getStatsFromFile(string filePath)
		//{
		//    StreamReader streamReader = new StreamReader(filePath);
		//    int health = int.Parse(streamReader.ReadLine());
		//    int Damage = int.Parse(streamReader.ReadLine());
		//    int Speed = int.Parse(streamReader.ReadLine());
		//    streamReader.Close();
		//    return new PlayerStats(health, Damage, Speed);
		//}
		//public void savePlayerStats()
		//{
		//    StreamWriter sw = new StreamWriter(savefilePath);
		//    sw.WriteLine(Stats.ToString());
		//    sw.Close();
		//}


		//public override void insertToMatrix(ref CharInfo[,] pixels)
		//{
		//	base.insertToMatrix(ref pixels);
			
		//	//foreach (Bullet bullet in Weapon.Bullets)
		//	//{
		//	//	bullet.insertToMatrix(ref pixels);
		//	//}
		//}
		public override void OnCollision(ConsoleObject otherObject)
        {
			//for (int i = 0; i < Weapon.Bullets.Count; i++)
			//{
			//	Bullet bullet = Weapon.Bullets[i];
			//	// bullets onCollision
			//	bullet.moveAngle();
			//	if(bullet.X >= Console.WindowWidth-Width-1 || bullet.X <= 0 ||
			//		bullet.Y <= 0 || bullet.Y >= Console.WindowHeight-Height-1
			//	)
			//	{
			//		Weapon.Bullets.RemoveAt(i);
			//		i--;
			//	}
			//}
            if (otherObject.GetType().Name == "Enemy") 
            {
                IsDisposed = true;
            }
            else if(otherObject.GetType().Name == "Background")
            {
                return;
            }
            else
            {
				Debug.WriteLine("Collided with " + otherObject.GetType().Name + DateTime.Now);

			}
		}
    }
}

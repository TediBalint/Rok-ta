using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.AnimationModules;
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
        public Player(double x, double y, int zIndex, int width, int height, string? filePath, Weapon weapon)
        : base(x, y, zIndex, width, height, filePath)
        {
            Weapon = weapon;
			Weapon.spawnPos = new double[2] { X + (Width - Weapon.Bullet.Width) / 2, Y - 2};
			//setStats();
			Animations.Add(new Animation("SaveFiles\\Objects\\Animations\\anim1.txt", this));
			Animations.Add(new Animation("SaveFiles\\Objects\\Animations\\anim2.txt", this, true));
        }
		public override void MoveRaw(double x, double y)
		{
			base.MoveRaw(x, y);
			Weapon.spawnPos = new double[2] { X + (Width - Weapon.Bullet.Width)/2, Y-2};
		}
		//private void setStats()
		//{
		//    string FilePath = savefilePath;
		//    if (!File.Exists(FilePath)) FilePath = $"SaveFiles\\Default\\defaultPlayer.txt";
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


		public override void OnCollision(ConsoleObject otherObject)
        {
			Animations[1].IsPaused = false;
            if (otherObject.GetType().Name == "Enemy") 
            {
                IsVissible = false;
				isMovable = false;
				Animations[0].IsPaused = false;
				Animations[1].IsPaused = true;
            }
            else if(otherObject.GetType().Name == "Background")
            {
                return;
            }
		}
    }
}

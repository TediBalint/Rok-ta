using Roketa.ConsoleObjectModules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
    internal class Player : ConsoleObject
    {
        public PlayerStats Stats { get; set; }
        public string Name { get; private set; }
        private string savefilePath;
        public Player(int x, int y, int zIndex, int width, int height, string? filePath, string name)
        : base(x, y, zIndex, width, height, filePath)
        {
            Name = name;
            savefilePath = $"SafeFiles\\Objects\\Players\\{name}.txt";
            setStats();
        }
        private void setStats()
        {
            string FilePath = savefilePath;
            if (!File.Exists(FilePath)) FilePath = $"SafeFiles\\Default\\defaultPlayer.txt";
            Stats = getStatsFromFile(FilePath);
        }
        private PlayerStats getStatsFromFile(string filePath)
        {
            StreamReader streamReader = new StreamReader(filePath);
            int health = int.Parse(streamReader.ReadLine());
            int Damage = int.Parse(streamReader.ReadLine());
            int Speed = int.Parse(streamReader.ReadLine());
            streamReader.Close();
            return new PlayerStats(health, Damage, Speed);
        }
        public void savePlayerStats()
        {
            StreamWriter sw = new StreamWriter(savefilePath);
            sw.WriteLine(Stats.ToString());
            sw.Close();
        }
        public override void OnCollision(ConsoleObject otherObject)
        {
            if (otherObject.GetType().Name == "Enemy") { 
                Debug.WriteLine("Collided with " + otherObject.GetType().Name + DateTime.Now);
                //Environment.Exit(0);
            }
        }
    }
}

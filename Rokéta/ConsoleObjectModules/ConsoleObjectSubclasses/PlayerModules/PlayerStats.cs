using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
    internal class PlayerStats
    {
        public int Health;
        public int Damage;
        public int Speed;

        public PlayerStats(int health, int damage, int speed)
        {
            Health = health;
            Damage = damage;
            Speed = speed;
        }
        public override string ToString()
        {
            return $"{Health}\n{Damage}\n{Speed}";
        }
    }
}

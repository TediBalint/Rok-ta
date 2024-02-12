using Roketa.ConsoleObjectModules;
using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.SoundModules;
using Rokéta.Statics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
    public class Weapon
    {
        public Bullet Bullet;
        private double Spread;
        private double FireRate;
        private int BulletAmount;
        public double[] spawnPos { get; set; }
        private string[] shootSounds;
        private readonly Stopwatch bulletTimer = new Stopwatch();
        public Weapon(Bullet bullet, double spread, double fire_rate, int bulletAmount, string[] _shootSounds)
        {
            Bullet = bullet;
            Spread = spread;
            FireRate = fire_rate;
            BulletAmount = bulletAmount;
            shootSounds = _shootSounds;
        }
        public void Shoot(ConsoleObjectFactory consoleObjectFactory)
        {
            int _bulletAmount = BulletAmount;
            double[] pos;
            if (bulletTimer.Elapsed.TotalSeconds > 1 / FireRate || !bulletTimer.IsRunning)
            {
                SoundManager.PlaySound(GetRandomShootSound());
                bulletTimer.Restart();
                if (_bulletAmount % 2 == 1)
                {
                    pos = new double[] { spawnPos[0], spawnPos[1] };
                    consoleObjectFactory.AddBullet(Bullet, 0, pos);
                    _bulletAmount--;
                }
                if (_bulletAmount <= 0)
                {
                    return;
                }
                double leftSide = Spread / -2;
                double rightSide = -leftSide;
                double step = Spread / _bulletAmount;
                for (double angle = leftSide; angle <= rightSide; angle += step)
                {
                    if (angle != 0)
                    {
                        pos = new double[] { spawnPos[0], spawnPos[1] };
                        consoleObjectFactory.AddBullet(Bullet, angle, pos);
                    }

                }



            }

        }
        private string GetRandomShootSound()
        {
            return shootSounds[Globals.Random.Next(0, shootSounds.Length)];
        }
    }
}

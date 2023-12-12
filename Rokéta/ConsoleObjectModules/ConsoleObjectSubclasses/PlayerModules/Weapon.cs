using Roketa.ConsoleObjectModules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
	public class Weapon
	{
		public List<Bullet> Bullets = new List<Bullet>();
		public Bullet Bullet;
		private double Spread;
		private double FireRate;
		private int BulletAmount;
		public double[] spawnPos { get; set; }

		public Weapon(Bullet bullet, double spread, double fire_rate, int bulletAmount) 
		{ 
			Bullet = bullet;
			Spread = spread;
			FireRate = fire_rate;
			BulletAmount = bulletAmount;
		}
		public void Shoot(Stopwatch bulletTimer)
		{
			if(bulletTimer.Elapsed.TotalSeconds > 1/FireRate)
			{
				if(BulletAmount % 2 == 1)
				{
					double angle = 0;
					Bullet bullet = Bullet.DeepCopy();
					bullet.angle = angle;
					bullet.X = spawnPos[0];
					bullet.Y = spawnPos[1] - 3;
					Bullets.Add(bullet);
				}
				double leftSide = Spread /-2;
				
				double rightSide = -leftSide;
				double step = Spread / BulletAmount;
				leftSide += step;
				rightSide -= step;
                Debug.WriteLine($"{leftSide}, {rightSide}, {step}");


                for (double angle = leftSide ; angle <= rightSide; angle+=step)
				{
					if (angle != 0)
					{
						Debug.WriteLine(angle + " " + BulletAmount);
                        Bullet bullet = Bullet.DeepCopy();
                        bullet.angle = angle;
                        bullet.X = spawnPos[0] + Spread / angle;
                        bullet.Y = spawnPos[1] - 3;
                        Bullets.Add(bullet);
                    }
					
				}
				//for (int i = 1; i < BulletAmount/2+1; i++)
				//{
				//	double angle = Spread / (BulletAmount/2) * i;
				//	Debug.Write(angle);
				//	Bullet bullet = Bullet.DeepCopy();
				//	bullet.angle = angle;
				//	bullet.X = spawnPos[0] + Spread / angle;
				//	bullet.Y = spawnPos[1] - 3;
				//	Bullets.Add(bullet);
				//}
				//for (int i = 1; i < BulletAmount / 2 + 1; i++)
				//{
				//	double angle = Spread / (BulletAmount / 2) * i - Spread/2;
				//	Debug.Write(angle);
				//	Bullet bullet = Bullet.DeepCopy();
				//	bullet.angle = angle;
				//	bullet.X = spawnPos[0] + Spread / angle;
				//	bullet.Y = spawnPos[1] - 3;
				//	Bullets.Add(bullet);
				//}

				//for (double angle = -Spread / 2; angle < Spread / 2; angle += Spread / BulletAmount)
				//{
				//	Bullet bullet = Bullet.DeepCopy();
				//	bullet.angle = angle;
				//	bullet.X = spawnPos[0] + Spread / angle;
				//	bullet.Y = spawnPos[1]-3;
				//	Bullets.Add(bullet);
				//}
				bulletTimer.Restart();

			}

		}
	}
}

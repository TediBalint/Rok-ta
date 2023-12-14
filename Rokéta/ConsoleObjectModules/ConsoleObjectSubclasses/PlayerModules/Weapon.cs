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
		public void Shoot(Stopwatch bulletTimer, ConsoleObjectFactory consoleObjectFactory)
		{
			int _bulletAmount = BulletAmount;
			double[] pos;
			if(bulletTimer.Elapsed.TotalSeconds > 1/FireRate)
			{
				if(_bulletAmount % 2 == 1)
				{
					pos = new double[] { spawnPos[0], spawnPos[1] };
					consoleObjectFactory.AddBullet(Bullet, 0, pos );
					_bulletAmount--;
				}

				double leftSide = Spread /-2;
				double rightSide = -leftSide;
				double step = Spread / _bulletAmount;
				Debug.WriteLine($"{leftSide}, {rightSide}, {step}");

				//leftSide += step;
				//rightSide -= step;
				Debug.WriteLine($"{leftSide}, {rightSide}, {step}");
				for (double angle = leftSide ; angle <= rightSide; angle+=step)
				{
					if (angle != 0)
					{
						//COULD BE USEFUL MAYBE
						//double spawnX = spawnPos[0] + Spread / angle; 


						pos = new double[] { spawnPos[0], spawnPos[1] };
						consoleObjectFactory.AddBullet(Bullet, angle, pos );
						Debug.WriteLine(angle);
                    }
					
				}
				
				bulletTimer.Restart();

			}

		}
	}
}

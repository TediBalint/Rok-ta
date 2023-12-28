using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules
{
    public class Enemy : ConsoleObject
    {
        private double[] velocity;
        private double Health;

        // stores bullets that hit this enemy already so bullets only hit it once
        private HashSet<ConsoleObject> hitBullets = new HashSet<ConsoleObject>();
        public Enemy(double x, double y, int zIndex, int? width, int? height, string? filePath, double[] _velocity, double health)
		: base(x, y, zIndex, width, height, filePath)
		{
            Health = health; 
			velocity = _velocity;
		}
        private void Movement()
        {
			MoveMotion(velocity[0], velocity[1], Globals.currentGameThicks);
            if(X >= Console.WindowWidth - Width || X <= Width)
            {
                velocity[0] *= -1;
            }
            if(Y >= Console.WindowHeight - Height || Y <= 0) 
            {
                velocity[1] *= -1;
            }
		}
		protected override string getSaveString()
		{
            return base.getSaveString() + $";{velocity[0]};{velocity[1]};{Health}";
		}
        private void Death()
        {
			Debug.WriteLine(Health);

		}
        private void TakeDamage(double damage)
        {
            Health -= damage;
            
            if(Health < 0 )
            {
                Death();
            }
        }
		public override void OnCollision(ConsoleObject otherObject)
        {
            if(otherObject.GetType() == typeof(Bullet))
            {
                if (!hitBullets.Contains(otherObject))
                {
					Bullet obj = (Bullet)otherObject;
					TakeDamage(obj.damage);
                    obj.pierce--;
                    if(obj.pierce <= 0)
                    {
                        obj.Delete();
                    }
                    hitBullets.Add(otherObject);
				}
            }
            else
            {
				Movement();

			}
		}
    }
}

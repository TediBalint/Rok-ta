using Roketa.ConsoleObjectModules;
using Rokéta.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules
{
    public class Enemy : ConsoleObject
    {
        private double[] velocity;
        public Enemy(double x, double y, int zIndex, int? width, int? height, string? filePath, double[] _velocity)
		: base(x, y, zIndex, width, height, filePath)
		{
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
            return base.getSaveString() + $";{velocity[0]};{velocity[1]}";
		}
		public override void OnCollision(ConsoleObject otherObject)
        {
            Movement();
            
            if(otherObject.GetType().Name == "Bullet")
            {
                IsDisposed = true;
            }
        }
    }
}

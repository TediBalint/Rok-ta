using Roketa.ConsoleObjectModules;
using Rokéta.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses
{
	public abstract class MovableObject : ConsoleObject
	{
        protected double[] velocity;
        public MovableObject(double x, double y, int zIndex, int? width, int? height, string? filePath, double[] _velocity)
		: base(x, y, zIndex, width, height, filePath)
        {
            velocity = _velocity;
        }
		private void Movement()
		{
			MoveMotion(velocity[0], velocity[1], Globals.currentGameThicks);
			if (X >= Console.WindowWidth - Width || X <= 0)
			{
				velocity[0] *= -1;
			}
			if (Y >= Console.WindowHeight - Height || Y <= 0)
			{
				velocity[1] *= -1;
			}
		}
		public override void OnCollision(ConsoleObject otherObject)
		{
			if(otherObject.GetType() == typeof(Background))
			{
				Movement();
			}
		}
	}
}

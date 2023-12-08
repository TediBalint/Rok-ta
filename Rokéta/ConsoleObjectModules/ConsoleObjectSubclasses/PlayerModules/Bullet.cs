using Roketa.ConsoleObjectModules;
using Rokéta.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
	public class Bullet : ConsoleObject
	{
		public double angle;
		private double speed;
		public Bullet(double x, double y, int z_Index, int width, int height, string? filePath, double _speed)
		: base(x, y, z_Index, width, height, filePath)
		{
			speed = _speed;
		}
		public override void OnCollision(ConsoleObject otherObject)
		{
			return;
		}
		public void moveAngle()
		{
			double moveX = Math.Sin(angle) * speed;
			double moveY;
			if (angle > 0) moveY = -Math.Cos(angle + 90) * speed;
			else moveY = -Math.Cos(angle - 90) * speed;
			MoveMotion(moveX, moveY, StaticVars.currentGameThicks);
		}
		public Bullet DeepCopy()
		{
			Bullet copy = new Bullet(X, Y, Z_Index, Width, Height, FilePath, speed)
			{
				angle = this.angle
			};
			// Perform deep copy for referenced objects here if needed
			return copy;
		}
	}
}

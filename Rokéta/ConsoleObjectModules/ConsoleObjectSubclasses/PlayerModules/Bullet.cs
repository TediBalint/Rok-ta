using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;
using Rokéta.Statics;
using System.Diagnostics;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
    public class Bullet : ConsoleObject
    {
        public double angle;
        public double speed;
        public Bullet(double x, double y, int z_Index, int width, int height, string? filePath, double _speed)
        : base(x, y, z_Index, width, height, filePath)
        {
            speed = _speed;
        }
        public override void OnCollision(ConsoleObject otherObject)
        {
            if(otherObject.GetType() == typeof(Background)) {
				MoveMotion(speed, speed, StaticVars.currentGameThicks);
                Debug.WriteLine(angle);
				if (IsOutOfMap()) IsDisposed = true;
			}
            
		}
        private bool IsOutOfMap()
        {
			if (X >= Console.WindowWidth - Width - 1 || X <= 0 ||
					Y <= 0 || Y >= Console.WindowHeight - Height - 1
            )
            {
                return true;
            }
            return false;

		}
		public override void MoveMotion(double x, double y, int currentGameThicks)
		{
			double moveX = Math.Sin(angle / 180 * Math.PI) * x;
			double moveY = Math.Cos(angle / 180 * Math.PI) * y;
            Debug.WriteLine($"X: {moveX} Y: {moveY}");
			base.MoveMotion(moveX, moveY, currentGameThicks);
		}
		//public void moveAngle()
  //      {
  //          Debug.WriteLine(angle);
  //          double moveX = Math.Sin(angle/180*Math.PI) * speed;
  //          double moveY = Math.Cos(angle / 180 * Math.PI) * speed;
  //          //if (angle > 0) moveY =;
  //          //else moveY = -Math.Cos(angle) * speed;
  //          MoveMotion(moveX, moveY, StaticVars.currentGameThicks);
  //      }
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

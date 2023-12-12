using Roketa.ConsoleObjectModules;
using Rokéta.Statics;
using System.Diagnostics;

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
            Debug.WriteLine(angle);
            double moveX = Math.Sin(angle/180*Math.PI) * speed;
            double moveY = Math.Cos(angle / 180 * Math.PI) * speed;
            //if (angle > 0) moveY =;
            //else moveY = -Math.Cos(angle) * speed;
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

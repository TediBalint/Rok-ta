using Rokéta.ConsoleObjectModules.AnimationModules;
using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses;
using Rokéta.Statics;
using System.Diagnostics;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
    public class Bullet : ConsoleObject
    {
        public double angle;
        private double speed;
        public double damage;
        public int pierce;
        private bool bounce;
        public Bullet(double x, double y, int z_Index, int width, int height, string? filePath, double _speed, double _damage, int _pierce, bool _bounce)
        : base(x, y, z_Index, width, height, filePath)
        {
            damage = _damage;
            speed = _speed;
            pierce = _pierce;
            bounce = _bounce;
            Animations.Add(new Animation("SaveFiles\\Objects\\Animations\\BulletExplosionAnim.txt", this, _destroyParent: true));
        }
        public override void OnCollision(ConsoleObject otherObject)
        {
            if (otherObject.GetType() == typeof(Background))
            {
                MoveMotion(speed, speed, Globals.currentGameThicks);
                if (IsOutOfMap()) IsDisposed = true;
            }
        }
        private bool IsOutOfMap()
        {
            if (X >= Console.WindowWidth - Width - 1 || X <= 0)
            {

                if (!bounce) return true;
                else
                {
                    angle = 360 - angle;
                    pierce--;
                    if (pierce <= 0)
                    {
                        bounce = false;
                    }
                }
            }
            else if (Y <= 0 || Y >= Console.WindowHeight - Height)
            {

                if (!bounce) return true;
                else
                {
                    angle = 180 - angle;
                    pierce--;
                    if (pierce <= 0)
                    {
                        bounce = false;
                    }
                }
            }
            return false;
        }
        public override void MoveMotion(double x, double y, int currentGameThicks)
        {
            double moveX = Math.Sin(angle / 180 * Math.PI) * x;
            double moveY = Math.Cos(angle / 180 * Math.PI) * y;
            base.MoveMotion(moveX, moveY, currentGameThicks);
        }
        public void Delete()
        {
            canCollide = false;
            IsVissible = false;
            isMovable = false;
            Animations[0].IsPaused = false;
        }
        public Bullet DeepCopy()
        {
            Bullet copy = new Bullet(X, Y, Z_Index, Width, Height, FilePath, speed, damage, pierce, bounce)
            {
                angle = angle
            };
            return copy;
        }
    }
}

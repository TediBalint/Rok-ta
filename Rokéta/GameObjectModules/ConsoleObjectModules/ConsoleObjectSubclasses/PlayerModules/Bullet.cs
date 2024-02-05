using Rokéta.ConsoleObjectModules.AnimationModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;


namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
    public class Bullet : PosPublicSet
    {
        public double angle { get; set; }
        private double speed;
        public double damage { get; set; }
        private int pierce;
        private bool bounce;

        private readonly HashSet<Enemy> CollidedEnemies = new HashSet<Enemy>();
        public Bullet(double x, double y, int z_Index, int width, int height, string? filePath, double _speed, double _damage, int _pierce, bool _bounce)
        : base(x, y, z_Index, width, height, filePath)
        {
            damage = _damage;
            speed = _speed;
            pierce = _pierce;
            bounce = _bounce;
            Animations.Add(new Animation("SaveFiles\\Objects\\Animations\\BulletExplosionAnim.txt", this,false));
        }
		public override void Update(ref CharInfo[,] pixels)
		{
			base.Update(ref pixels);
			MoveMotion(speed, speed);
			if (IsOutOfMap()) IsDisposed = true;
            CollidedEnemies.Clear();
		}
		public override void OnCollision(ConsoleObject otherObject)
		{
            
            if(otherObject.GetType() == typeof(Enemy))
            {
                Enemy enemy = (Enemy)otherObject;
                if(!CollidedEnemies.Contains(enemy))
                {
					CollidedEnemies.Add(enemy);
					pierce--;
					if (pierce <= 0)
					{
						Delete();
					}
				}
				
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
        public override void MoveMotion(double x, double y)
        {
            double moveX = Math.Sin(angle / 180 * Math.PI) * x;
            double moveY = Math.Cos(angle / 180 * Math.PI) * y;
            base.MoveMotion(moveX, moveY);
        }
        private void Delete()
        {
            CanCollide = false;
            IsVissible = false;
            IsMovable = false;
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

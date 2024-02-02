using Rokéta.ConsoleObjectModules.AnimationModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.Statics;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules
{
    public class Enemy : MovableObject
    {
        public double Health;
		// stores bullets that hit this enemy already so bullets only hit it once
		private HashSet<ConsoleObject> hitBullets = new HashSet<ConsoleObject>();
        public Enemy(double x, double y, int zIndex, int? width, int? height, string? filePath, double[] _velocity, double health)
        : base(x, y, zIndex, width, height, filePath, _velocity)
        {
            Health = health;
            Animations.Add(new Animation("SaveFiles\\Objects\\Animations\\PlayerDeathAnim.txt", this, _destroyParent: true));
        }
        protected override string getSaveString()
        {
            return base.getSaveString() + $";{Math.Round(velocity[0], 2)};{Math.Round(velocity[1], 2)};{Math.Round(Health),2}";
        }
        private void Death()
        {
            CanCollide = false;
            IsVissible = false;
            IsMovable = false;
            Globals.enemyCount--;
            Globals.kills++;
            Animations[0].IsPaused = false;
            //SoundManager.PlaySound("PlayerDeathSound1");
        }
        private void TakeDamage(double damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Death();
            }
        }
        public override void OnCollision(ConsoleObject otherObject)
        {
            base.OnCollision(otherObject);
            if (otherObject.GetType() == typeof(Bullet))
            {
                if (!hitBullets.Contains(otherObject))
                {
                    Bullet obj = (Bullet)otherObject;
                    TakeDamage(obj.damage);
                    hitBullets.Add(otherObject);
                }
            }
        }
    }
}

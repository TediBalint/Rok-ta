using Rokéta.ConsoleObjectModules.AnimationModules;
using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using System.Diagnostics;

namespace Rokéta.GameObjectModules.AnimationModules.AnimationSubclasses
{
    public class BoosterAnim : Animation
    {
        private readonly Booster booster;
        public BoosterAnim(ConsoleObject parent, Booster _booster) : base(_booster.FilePath, parent, true)
        {
            booster = _booster;
        }
        public override bool IsCollision(ConsoleObject otherObject)
        {
            return base.IsCollision(otherObject);
        }
        public override void OnCollision(ConsoleObject otherObject)
        {
            if(otherObject.GetType() == typeof(Enemy))
            {
                Enemy enemy = (Enemy)otherObject;
                if (booster.IsDamageReady) {
                    enemy.TakeDamage(booster.Damage);
                    booster.IsDamageReady = true;
                    Debug.WriteLine("Deal Damage");
                }
            }
        }
    }
}

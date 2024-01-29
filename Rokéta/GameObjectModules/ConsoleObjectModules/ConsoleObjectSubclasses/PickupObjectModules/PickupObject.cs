using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PickupObjectModules
{
    public abstract class PickupObject : MovableObject
    {
        public PickupObject(double x, double y, int zIndex, int? width, int? height, string? filePath, double[] _velocity)
        : base(x, y, zIndex, width, height, filePath, _velocity) { }
        protected abstract void Effect(Player player);
        public override void OnCollision(ConsoleObject otherObject)
        {
            base.OnCollision(otherObject);
            if (otherObject.GetType() == typeof(Player))
            {
                Effect(otherObject as Player);
            }
        }
    }
}

using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.Statics;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses
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
            if (otherObject.GetType() == typeof(Background))
            {
                Movement();
            }
        }
    }
}

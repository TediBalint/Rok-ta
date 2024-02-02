using Rokéta.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.AnimationModules;
using Rokéta.Statics;

namespace Rokéta.GameObjectModules.ConsoleObjectModules
{
    public abstract class ConsoleObject : GameObject
    {
        public bool IsMovable { get; protected set; } = true;
        public bool IsVissible { get; protected set; } = true;
        public bool CanCollide { get; protected set; } = true;
		public List<Animation> Animations { get; set; }
        public abstract void OnCollision(ConsoleObject otherObject);
        public ConsoleObject(double x, double y, int zIndex, int? width, int? height, string? filePath = null):base(x,y,zIndex,width,height,filePath)
        {
            Animations = new List<Animation>();
        }
        public virtual void MoveMotion(double x, double y)
        {
            if (IsMovable)
            {
                X += x / Globals.currentGameThicks;
                Y -= y / Globals.currentGameThicks;
                Snap();
            }
        }
        public virtual void MoveMotion(double[] cords)
        {
            if(IsMovable)
            {
                X += cords[0] / Globals.currentGameThicks;
                X += cords[1] / Globals.currentGameThicks;
			}
        }
        public virtual void Snap()
        {
            X = Math.Min(X, Console.WindowWidth - Width);
            X = Math.Max(X, 0);
            Y = Math.Min(Y, Console.WindowHeight - Height + 1);
            Y = Math.Max(Y, 0);
        }
		public override void Update(ref CharInfo[,] pixels)
		{
			Snap();
			if (IsVissible)
			{
				base.Update(ref pixels);
			}
			// render animations
			foreach (Animation anim in Animations)
			{
				anim.Render(ref pixels);
			}
		}
		protected virtual string getSaveString()
        {
            // double x, double y, int zIndex, int? width, int? height,string? filePath
            return $"{GetType().Name};{Math.Round(X, 2)};{Math.Round(Y)};{Z_Index};{Width};{Height};{FilePath}";
        }
        public void SaveToFile(StreamWriter sw)
        {
            sw.WriteLine(Encrypter.Encrypt(getSaveString()));
        }
        public virtual bool IsCollision(ConsoleObject otherObject)
        {
            if (!CanCollide) return false;
            if
            (
                // AABB algorithm
                 otherObject != this &&
                 IsXOverlapping(otherObject) &&
                 IsYOverlapping(otherObject)

                //otherObject != this &&
                //(int)X < (int)(otherObject.X + otherObject.Width) &&
                //(int)(X + Width) > (int)otherObject.X &&
                //(int)Y < (int)(otherObject.Y + otherObject.Height) &&
                //(int)(Y + Height) > (int)otherObject.Y
            )
            {
                return true;
            }

            return false;
        }
    }
}

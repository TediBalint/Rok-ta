using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses;

namespace Rokéta.ConsoleObjectModules.AnimationModules
{
    public class AnimationObject : PosPublicSet
	{
		public double Xoffset { get;set; }
		public double Yoffset { get;set; }
		public AnimationObject(ConsoleObject parent, CharInfo?[,] charInfos) 
			: base(parent.X-parent.Width/2, parent.Y-parent.Height/2, parent.Z_Index, charInfos.GetLength(1),charInfos.GetLength(0), "")
		{
			CharInfos = charInfos;
		}
		public override void OnCollision(ConsoleObject otherObject)
		{
			// no collision detection needed with animations
			return;
		}
	}
}

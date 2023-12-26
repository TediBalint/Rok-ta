using Roketa.ConsoleObjectModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.AnimationModules
{
	public class AnimationObject : ConsoleObject
	{
		public double xOffset { get;set; }
		public double yOffset { get;set; }
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

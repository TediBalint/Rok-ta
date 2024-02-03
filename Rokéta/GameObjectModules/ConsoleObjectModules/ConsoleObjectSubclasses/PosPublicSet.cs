using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses
{
	public class PosPublicSet : ConsoleObject
	{
		public PosPublicSet(double x, double y, int zIndex, int? width, int? height, string? filePath = null) : base(x, y, zIndex, width, height, filePath)
		{
		}
		public void SetPos(double x, double y)
		{
			X = x; Y = y;
		}
		public void SetPos(double[] pos)
		{
			X = pos[0]; Y = pos[1];
		}
		public override void OnCollision(ConsoleObject otherObject)
		{
			return;
		}
	}
}

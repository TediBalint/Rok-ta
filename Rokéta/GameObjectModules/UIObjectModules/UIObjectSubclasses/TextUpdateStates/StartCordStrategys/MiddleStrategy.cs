using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.StartCordStrategys
{
	public class MiddleStrategy : IStartCordStrategy
	{
		public int[] GetStartCords(int width, int height, int textLength, Padding padding)
		{
			return new int[] { 0, 0 };
		}
	}
}

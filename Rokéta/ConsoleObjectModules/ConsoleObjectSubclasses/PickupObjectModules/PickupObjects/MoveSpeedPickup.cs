using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PickupObjectModules.PickupObjects
{
	public class MoveSpeedPickup : PickupObject
	{
		private double speedBouns;
        public MoveSpeedPickup(double x, double y, int zIndex, double[] _velocity, double _speedBonus)
		: base(x, y, zIndex,0,0, "\\SaveFiles\\HealthObject\\Objects\\PickupObjects\\HeathObject.txt", _velocity)
        {
            speedBouns = _speedBonus;
        }
		protected override void Effect(Player player)
		{
			player.MovementSpeed[0] += speedBouns;
			player.MovementSpeed[1] += speedBouns;
		}
	}
}

using Rokéta.ConsoleObjectModules.AnimationModules;
using System.Diagnostics;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
	public class Booster
	{
		public Animation BoosterAnim { get; private set; }
		public int Damage { get;private set; }
		private int damageInterval;
		private Stopwatch interval = new Stopwatch();

		public Booster(Animation boosterAnim, int damage, int _damageInterval)
		{
			BoosterAnim = boosterAnim;
			Damage = damage;
			damageInterval = _damageInterval;
			interval.Start();
		}
		public bool IsDamageReady()
		{
			return interval.ElapsedMilliseconds > damageInterval;
		}
		public void RestartInterval()
		{
			interval.Restart();
		}
	}
}

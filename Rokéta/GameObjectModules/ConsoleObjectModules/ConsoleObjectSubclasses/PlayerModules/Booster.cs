using System.Diagnostics;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
	public class Booster
	{
		public int Damage { get; private set; }
		private uint damageInterval;
		private Stopwatch interval = new Stopwatch();
		public readonly string FilePath;
		public readonly string Name;
		public bool IsDamageReady { 
			get
			{
				return interval.ElapsedMilliseconds > damageInterval;
			}
			set
			{
				if (!value) interval.Restart();
			}
		}
		public Booster(int damage,uint _damageInterval, string filePath, string name)
		{
			Name = name;
			FilePath = filePath;
			Damage = damage;
			damageInterval = _damageInterval;
			interval.Start();
		}
	}
}

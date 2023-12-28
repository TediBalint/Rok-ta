using Rokéta.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.Statics
{
	public static class Globals
	{
		public static Random Random = new Random();
		public static int currentGameThicks = 2000;
		public static bool isMusicEnabled = false;
		public static bool isGameSoundEnabled = true;
		public static int kills = 0;
	}
}

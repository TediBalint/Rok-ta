using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.Statics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses
{
	public class Background : ConsoleObject
	{
		private int lastKills;
		public Background(ConsoleColor? color = null, string? filePath = null) : base(0, 0, 0, Console.WindowWidth, Console.WindowHeight, filePath)
		{
			if(color != null)
			{
				Fill(color.Value);
			}
		}
		public override void OnCollision(ConsoleObject otherObject)
		{
			if (otherObject.GetType() == typeof(Player))
			{
				if (lastKills != Globals.kills)
				{
					string newBgPath = GetBackgroundFilePath();
					if (newBgPath != FilePath)
					{
						FilePath = newBgPath; 
						readFile();
					}
				}
				
				lastKills = Globals.kills;
			}

			return;
		}
		private string GetBackgroundFilePath()
		{
			foreach (int killCount in Defaults.backgrounds.Keys)
			{
				if(Globals.kills >= killCount) return Defaults.backgrounds[killCount];
			}
			return Defaults.backgrounds.Last().Value;
        }
		
	}
}

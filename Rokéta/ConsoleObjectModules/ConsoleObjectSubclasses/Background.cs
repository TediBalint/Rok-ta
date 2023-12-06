using Roketa.ConsoleObjectModules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses
{
	internal class Background : ConsoleObject
	{
		public Background(ConsoleColor color) : base(0, 0, 0, Console.WindowWidth, Console.WindowHeight, null)
		{
			Fill(color);		
		}
		public override void OnCollision(ConsoleObject otherObject)
		{
			return;
		}
	}
}

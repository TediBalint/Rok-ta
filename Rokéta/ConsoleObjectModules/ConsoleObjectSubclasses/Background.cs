using Roketa.ConsoleObjectModules;
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
		public Background(ConsoleColor? color = null, string? filePath = null) : base(0, 0, 0, Console.WindowWidth, Console.WindowHeight, filePath)
		{
			if(color != null)
			{
				Fill(color.Value);
			}
		}
		public override void OnCollision(ConsoleObject otherObject)
		{
			return;
		}
	}
}

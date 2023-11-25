using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roketa.ConsoleObject
{
	internal static class Colors
	{
		//public static ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
		public static Dictionary<string, ConsoleColor?> colorDictionary = new Dictionary<string, ConsoleColor?>()
		{
			{"bl", ConsoleColor.Black},
			{"db", ConsoleColor.DarkBlue },
			{"dg", ConsoleColor.DarkGreen },
			{"dr", ConsoleColor.DarkRed},
			{"dm", ConsoleColor.DarkMagenta },
			{"dy", ConsoleColor.DarkYellow },
			{"ga", ConsoleColor.Gray },
			{"da", ConsoleColor.DarkGray },
			{"bu", ConsoleColor.Blue},
			{"gr", ConsoleColor.Green },
			{"cy", ConsoleColor.Cyan },
			{"re", ConsoleColor.Red },
			{"ma", ConsoleColor.Magenta },
			{"ye", ConsoleColor.Yellow },
			{"wh", ConsoleColor.White },
			{ "--" , null}
		};
	}
}
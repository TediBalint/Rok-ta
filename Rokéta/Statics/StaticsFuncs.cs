using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.Statics
{
	public static class StaticsFuncs
	{
		public static void WarningWithLineNumber(string message)
		{
			StackTrace stackTrace = new StackTrace();
			int lineNumber = stackTrace.GetFrame(1).GetFileLineNumber();
			Console.WriteLine($"Warning at line {lineNumber}: {message}");
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fuzzierinter
{
	internal class Logger
	{
		public static void DebugMSG(string msg)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("- [DEBUG] " + msg);
		}
		public static void ErrorMSG(string msg)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("- [ERROR] " + msg);
		}
		public static void InfoMSG(string msg)
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("- [INFO] " + msg);
		}
	}
}

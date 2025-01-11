using System;
using System.Diagnostics;

namespace fuzzierinter
{
	class Program
	{
		static void Main(string[] args)
		{
			Program this_obj = new Program();
			string Query;

			if (args.Length == 0)
			{
				args = ["-"]; // Make it run the "ask the user" part
			}

			if (args[0] != "-r" && args[0] != "--results") // -r or --results just show the results
			{
				Console.WriteLine("    FUZZIERINTER CLI VERSION 0.1    ");
				Console.WriteLine("====================================");
				Console.WriteLine("Please, note that the Web version is available at https://mariluski23.github.io/fuzzierinter/");
				Console.Write("Please, enter a query: ");
				try
				{
					Query = Console.ReadLine()!;
				} catch (Exception e)
				{
					Logger.ErrorMSG("Failed to read query: " + e.Message);
					return;
				}
			}
			else
			{
				// search for the query after the -r or --results flag
				string query = args[1];
				Console.WriteLine(query);
			}
		}
	}
}

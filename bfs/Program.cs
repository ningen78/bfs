using System;

namespace bfs;

public static class Program
{
	private static void Main(string[] args)
	{
		var start = DateTime.Now;
		Console.WriteLine($"Begin: {start:yyyy-MM-dd HH:mm:ss}");
		switch (args.Length)
		{
			case < 1 or >= 3:
				PrintHelp();
				break;
			case 1:
				Searcher.Search(args[0]);
				break;
			case 2:
				Searcher.Search(args[1], args[0]);
				break;
		}

		var end = DateTime.Now;
		Console.WriteLine($"Ran for: {end - start:G}");
	}
	
	private static void PrintHelp()
	{
		Console.WriteLine("bsf [start directory] filename part");
	}
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace bfs;

public static class Searcher
{
	public static void Search(string namePart, string directory)
	{
		Console.WriteLine($"Searching for '{namePart}' in {directory} and below");
		foreach (var foundFile in Searcher.FoundFiles(namePart, directory))
		{
			Console.WriteLine(foundFile);
		}
	}

	public static void Search(string namePart)
	{
		var curDir = Directory.GetCurrentDirectory();
		Search(namePart, curDir);
	}

	public static IEnumerable<string> FoundFiles(string namePart, string directory)
	{
		var found = new ConcurrentQueue<string>();
		Parallel.ForEach(Directory.GetDirectories(directory), dir =>
		{
			if (!Directory.Exists(dir))
				return;
			try
			{
				Parallel.ForEach(FoundFiles(namePart, dir), fn => found.Enqueue(fn));
			}
			catch
			{
				// ignored
			}
		});
		try
		{
			Parallel.ForEach(Directory.GetFiles(directory, namePart), fn => { Console.WriteLine(fn); });
		}
		catch
		{
			// ignored
		}

		return found.ToArray();
	}
}
using DaySix.Model;
using System;
using System.IO;
using System.Linq;

namespace DaySix
{
	class Program
	{
		static void Main(string[] args)
		{
			var path = $"Resources/input.txt";
			try
			{
				if (!File.Exists(path)) throw new FileNotFoundException(path);

				var lines = File.ReadAllLines(path);

				if (lines.Count() == 0) throw new Exception($"File {path} is empty.");

				var map = new Map(lines, "COM");
				Console.WriteLine(map.TotalNumberOfDirectAndIndirectOrbits());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}

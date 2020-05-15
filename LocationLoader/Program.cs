using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LocationLoader
{
	class Program
	{
		static void Main(string[] args)
		{
			var gameLocations = GetGameLocations().ToArray();
			var jsonText = JsonConvert.SerializeObject(gameLocations);
			File.WriteAllText($"AllLocations.json", jsonText);
		}

		private static IEnumerable<GameLocation> GetGameLocations()
		{
			foreach (var directory in Directory.GetDirectories("Assets/"))
			{
				var files = new DirectoryInfo(directory).GetFiles();

				yield return new GameLocation
				(
					GetContentByExtension(files, ".css"),
					GetContentByExtension(files, ".html"),
					GetContentByExtension(files, ".txt").Split(Environment.NewLine).ToList()
				);
			}
		}

		private static string GetContentByExtension(FileInfo[] files, string extension)
		{
			var file = files.FirstOrDefault(f => f.Extension == extension)
				?? throw new Exception($"Не найден файл по расширению - {extension}");

			return File.ReadAllText(file.FullName);
		}
	}
}

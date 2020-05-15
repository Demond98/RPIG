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
					getContentbyExtension(".css"),
					getContentbyExtension(".html"),
					getContentbyExtension(".txt").Split(Environment.NewLine).ToList()
				);

				var jsonText = JsonConvert.SerializeObject(gameLocation);
				var fileName = directory[directory.LastIndexOf('/')..];

				if (!Directory.Exists("out/"))
					Directory.CreateDirectory("out");

				File.WriteAllText($"out/{fileName}.json", jsonText);
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

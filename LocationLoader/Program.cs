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
			WriteGameLocations();
		}

		private static void WriteGameLocations()
		{
			foreach (var directory in Directory.GetDirectories("Assets/"))
			{
				var files = new DirectoryInfo(directory).GetFiles();
				string getContentbyExtension(string extension) => GetContentByExtension(files, extension);

				var gameLocation = new GameLocation
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

using System.Runtime.CompilerServices;
using System.Diagnostics.Tracing;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Serilog;
using Serilog.Events;


using GalaxyMap.Models;
using GalaxyMap.Utilities;


Planet earth = new("Earth", 5.972e24, 6372e3, 0);
BlackHole sagittarius = new("Sagittarius A*", 8.26e36, 12e6);
string imagesDir = Path.Combine(Environment.CurrentDirectory, "images");
IEnumerable<string> images = Directory.EnumerateFiles(imagesDir);
foreach (string pathOfImage in images)
{
	string pathThumbnail = Path.Combine(Environment.CurrentDirectory, "images", Path.GetFileNameWithoutExtension(pathOfImage) + "-thumbnail" + Path.GetExtension(pathOfImage));
	using (Image image = Image.Load(pathOfImage))
	{
		image.Mutate(x => x.Resize(image.Width / 10, image.Height / 10));
		image.Mutate(x => x.Grayscale());
		image.Save(pathThumbnail);
	}
}
System.Console.WriteLine("Images processing finished.");

Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.Console()
				.Enrich.FromLogContext()
				.WriteTo.File(Path.Combine(Environment.CurrentDirectory, "log.txt"), rollingInterval: RollingInterval.Day)
				.CreateLogger();









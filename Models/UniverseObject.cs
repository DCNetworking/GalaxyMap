
using System.Diagnostics;
using GalaxyMap.Utilities;

namespace GalaxyMap.Models
{
	public abstract class UniverseObject
	{
		public double MassKg { get; private set; }
		public string? Name { get; private set; }
		public double LightYearsDistanceFromEarth { get; private set; }
		public double RadiusMeters { get; private set; }
		public UniverseObjectType UniverseObjectType { get; protected set; }
		public UniverseObject(
			string name,
			double massKg = -1,
			double radiusMeters = -1,
			double lightYearsDistanceFromEarth = -1
			)
		{
			Name = name is null ? throw new ArgumentNullException(nameof(name)) : name;
			MassKg = massKg;
			RadiusMeters = radiusMeters;
			LightYearsDistanceFromEarth = lightYearsDistanceFromEarth;
		}
		public double GravityForceN()
		{
			if (MassKg != -1 && RadiusMeters != -1)
			{
				Trace.WriteLine($"Cant properly calculate GravityForvce (N) with given Values : {nameof(MassKg)}:{MassKg} {nameof(RadiusMeters)}:{RadiusMeters}");
				return 0;
			}
			return (PhysicalConstants.G * MassKg) / Math.Pow(RadiusMeters, 2);
		}
		// public double GravityForceNToObject(UniverseObject universeObject)
		// {
		// 	if (MassKg != -1 && RadiusMeters != -1 && LightYearsDistanceFromEarth != -1)
		// 	{

		// 	}
		// }
		public double GravityForceNDiff(UniverseObject universeObject)
		{
			return MathService.DivideByZero(this.GravityForceN(), universeObject.GravityForceN());
		}
		public static double GravityForceNDiff(UniverseObject universeObjectFirst, UniverseObject universeObjectSecond)
		{
			return MathService.DivideByZero(universeObjectFirst.GravityForceN(), universeObjectSecond.GravityForceN());
		}

	}
}
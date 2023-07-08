
using GalaxyMap.Utilities;

namespace GalaxyMap.Models
{
	public abstract class UniverseObject
	{
		public double MassKg { get; private set; }
		public string? Name { get; private set; }
		public double AUDistance { get; private set; }
		public double RadiusMeters { get; private set; }
		public UniverseObjectType UniverseObjectType { get; protected set; }
		public UniverseObject(
			string name,
			double massKg = -1,
			double radiusMeters = -1,
			double aUDistance = -1
			)
		{
			Name = name is null ? throw new ArgumentNullException(nameof(name)) : name;
			MassKg = massKg;
			RadiusMeters = radiusMeters;
			AUDistance = aUDistance;
		}
		public double GravityForceN()
		{
			return (PhysicalConstants.G * MassKg) / Math.Pow(RadiusMeters, 2);
		}
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
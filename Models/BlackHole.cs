using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyMap.Models
{
	public class BlackHole : UniverseObject
	{
		public BlackHole(string name, double massKg = -1, double radiusMeters = -1, double aUDistance = -1) 
		: base(name, massKg, radiusMeters, aUDistance)
		{
			UniverseObjectType = UniverseObjectType.BlackHole;
		}
	}
}
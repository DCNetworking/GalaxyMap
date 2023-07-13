using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaxyMap.Utilities;
namespace GalaxyMap.Models
{
    /// <summary>
    /// Represents a black hole in the universe.
    /// </summary>
    public class BlackHole : UniverseObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlackHole"/> class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the black hole.</param>
        /// <param name="massKg">The mass of the black hole in kilograms (optional).</param>
        /// <param name="description">Short description of blackhole.</param>
        /// <param name="radiusMeters">The radius of the black hole in meters (optional).</param>
        /// <param name="aUDistance">The distance of the black hole from Earth in astronomical units (optional).</param>
        public BlackHole(string name, string descrpition, double massKg = -1, double radiusMeters = -1, double aUDistance = -1)
            : base(name, descrpition, massKg, radiusMeters, aUDistance)
        {
            UniverseObjectType = UniverseObjectType.BlackHole;
        }
    }
}
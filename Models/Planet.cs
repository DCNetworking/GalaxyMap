using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyMap.Models
{
    /// <summary>
    /// Represents a planet in the universe.
    /// </summary>
    public class Planet : UniverseObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Planet"/> class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the planet.</param>
        /// <param name="massKg">The mass of the planet in kilograms (optional).</param>
        /// <param name="description">Short description of planet.</param>
        /// <param name="radiusMeters">The radius of the planet in meters (optional).</param>
        /// <param name="aUDistance">The distance of the planet from Earth in astronomical units (optional).</param>
        public Planet(string name, string description, double massKg = -1, double radiusMeters = -1, double aUDistance = -1)
            : base(name, description, massKg, radiusMeters, aUDistance)
        {
            UniverseObjectType = UniverseObjectType.Planet;
        }
    }
}
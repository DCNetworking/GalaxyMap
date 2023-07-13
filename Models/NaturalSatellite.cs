using System;
namespace GalaxyMap.Models
{
    /// <summary>
    /// Represents a NaturalSatelite in the universe.
    /// </summary>
    public class NaturalSatellite : UniverseObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="NaturalSatellite"/> class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the planet.</param>
        /// <param name="massKg">The mass of the planet in kilograms (optional).</param>
        /// <param name="description">Short description of planet.</param>
        /// <param name="radiusMeters">The radius of the planet in meters (optional).</param>
        /// <param name="aUDistance">The distance of the planet from Earth in astronomical units (optional).</param>
        public NaturalSatellite(string name, string description, double massKg = -1, double radiusMeters = -1, double aUDistance = -1)
            : base(name, description, massKg, radiusMeters, aUDistance)
        {
            UniverseObjectType = UniverseObjectType.NaturalSatellite;
        }
    }
}

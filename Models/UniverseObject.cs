
using System.Diagnostics;
using GalaxyMap.Utilities;

namespace GalaxyMap.Models
{
    /// <summary>
    /// Represents an abstract object in the universe.
    /// </summary>
    [CreateTable("universe-objects")]
    public abstract class UniverseObject
    {
        static int _id = 1;
        [TableColumn("id", SQLColumnType.INTEGER, SQLKeyType.Primary)]
        public int Id { get; protected set; }
        /// <summary>
        /// Gets or sets the mass of the object in kilograms.
        /// </summary>
        [TableColumn("mass_kg", SQLColumnType.NUMERIC, SQLKeyType.None)]
        public double MassKg { get; protected set; }

        /// <summary>
        /// Gets or sets the name of the object.
        /// </summary>
        [TableColumn("name", SQLColumnType.TEXT, SQLKeyType.None)]
        public string Name { get; protected set; }

        /// <summary>
        /// Gets or sets the distance of the object from Earth in light-years.
        /// </summary>
        [TableColumn("light_years_distance_from_earth", SQLColumnType.NUMERIC, SQLKeyType.None)]
        public double LightYearsDistanceFromEarth { get; protected set; }

        /// <summary>
        /// Gets or sets the radius of the object in meters.
        /// </summary>
        [TableColumn("radius_meters", SQLColumnType.NUMERIC, SQLKeyType.None)]
        public double RadiusMeters { get; protected set; }

        /// <summary>
        /// Gets the Schwarzschild radius of the object in meters.
        /// </summary>
        [TableColumn("schwarzschild_radius_meters", SQLColumnType.NUMERIC, SQLKeyType.None)]
        public double SchwarzschildRadiusMeters { get; private set; }

        /// <summary>
        /// Gets the type of the universe object.
        /// </summary>
        [TableColumn("universe_object_type", SQLColumnType.TEXT, SQLKeyType.None)]
        public UniverseObjectType UniverseObjectType { get; protected set; }

        /// <summary>
        /// Gets the Description of the universe object.
        /// </summary>
        [TableColumn("description", SQLColumnType.TEXT, SQLKeyType.None)]
        public string Description { get; private set; }

        /// <summary>
        /// If Star - Gets the StarType.
        /// </summary>
        [TableColumn("star_type", SQLColumnType.TEXT, SQLKeyType.None)]
        public StarType StarType { get; protected set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UniverseObject"/> class with the specified parameters.
        /// </summary>
        /// <param name="name">The name of the object.</param>
        /// <param name="massKg">The mass of the object in kilograms (optional).</param>
        /// <param name="radiusMeters">The radius of the object in meters (optional).</param>
        /// <param name="lightYearsDistanceFromEarth">The distance of the object from Earth in light-years (optional).</param>
        /// <exception cref="ArgumentNullException">Thrown when the provided name is null.</exception>
        public UniverseObject(
            string name,
            string description,
            double massKg = -1,
            double radiusMeters = -1,
            double lightYearsDistanceFromEarth = -1
        )
        {
            Name = name is null ? throw new ArgumentNullException(nameof(name)) : name;
            Description = description;
            MassKg = massKg;
            RadiusMeters = radiusMeters;
            LightYearsDistanceFromEarth = lightYearsDistanceFromEarth;
            SchwarzschildRadiusMeters = MathService.SchwarzchildRadius(massKg);
            Id = _id;
            _id++;
        }

        /// <summary>
        /// Calculates the gravitational force exerted by the object in newtons.
        /// </summary>
        /// <returns>The gravitational force in newtons.</returns>
        public double GravityForceN()
        {
            if (MassKg == -1 || RadiusMeters == -1)
            {
                Trace.WriteLine($"Cannot properly calculate GravityForce (N) with given values: {nameof(MassKg)}:{MassKg} {nameof(RadiusMeters)}:{RadiusMeters}");
                return 0;
            }

            checked
            {
                return (PhysicalConstants.G * MassKg) / Math.Pow(RadiusMeters, 2);
            }
        }

        /// <summary>
        /// Calculates the difference in gravitational force between this object and the specified universe object.
        /// </summary>
        /// <param name="universeObject">The universe object to compare against.</param>
        /// <returns>The difference in gravitational force.</returns>
        public double GravityForceNDiff(UniverseObject universeObject)
        {
            return MathService.DivideByZero(this.GravityForceN(), universeObject.GravityForceN());
        }

        /// <summary>
        /// Calculates the difference in gravitational force between two universe objects.
        /// </summary>
        /// <param name="universeObjectFirst">The first universe object.</param>
        /// <param name="universeObjectSecond">The second universe object.</param>
        /// <returns>The difference in gravitational force.</returns>
        public static double GravityForceNDiff(UniverseObject universeObjectFirst, UniverseObject universeObjectSecond)
        {
            return MathService.DivideByZero(universeObjectFirst.GravityForceN(), universeObjectSecond.GravityForceN());
        }
    }
}
using System.Dynamic;
using System;
using static System.Console;
using Serilog;
using GalaxyMap.Models;
using GalaxyMap.Utilities;
using GalaxyMap.Repository;
using System.Data.SQLite;

User user = new();
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithProperty("IpAddress", user.IPv4Address)
                .Enrich.WithProperty("System", user.SystemName)
                .WriteTo.Console(outputTemplate: LoggerConstants.LoggerTemplate)
                .WriteTo.File(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Kod", "GalaxyMap", LoggerConstants.LoggerFileName), rollingInterval: RollingInterval.Day, outputTemplate: LoggerConstants.LoggerTemplate)
                .CreateLogger();

Log.Information("Session started");
GalaxyMapRepository repo = GalaxyMapRepository.InitRepo(Log.Logger);
List<UniverseObject> universeObjects = await repo.GetAllUniverseObjects();
List<UniverseObject> objectList = new()
{
new BlackHole("Sagittarius A*", "Biggest Black Hole in Milky Way Galaxy", 8.567e36, 1.2e7)  ,
new BlackHole("Messier 87", "Supermassive Black Hole in the center of Virgo A galaxy", 6.5e39, 1.23e8)  ,
new BlackHole("Cygnus X-1", "High-mass X-ray binary black hole system", 2.63e35, 2.14e6)    ,
new BlackHole("V404 Cygni", "Transient black hole system in the constellation Cygnus", 9.1e34, 1.14e6)  ,
new BlackHole("S5 0014+81", "Active galactic nucleus with a supermassive black hole", 2.6e39, 1.19e8)   ,
new BlackHole("Centaurus A", "Radio galaxy with a prominent black hole in the center", 2.2e39, 1.17e8)  ,
new BlackHole("OJ 287", "Blazar with a binary black hole system", 1.83e38, 6.84e7)  ,
new BlackHole("A0620-00", "Low-mass X-ray binary with a black hole primary", 6.6e31, 2.36e5)    ,
new BlackHole("V4641 Sagittarii", "Black hole system in the constellation Sagittarius", 9.1e32, 3.56e5) ,
new BlackHole("NGC 1277", "Galaxy with an unusually massive black hole", 1.7e40, 1.4e8) ,
new BlackHole("TON 618", "Quasar with one of the most massive black holes", 4.5e40, 1.7e8)  ,
new BlackHole("M33 X-7", "High-mass X-ray binary black hole in the Triangulum Galaxy", 2.45e34, 1.66e6) ,
new BlackHole("4U 1543-47", "Black hole X-ray binary in the constellation Norma", 1.77e32, 3.98e5)  ,
new BlackHole("3C 273", "Quasar with a supermassive black hole", 1.42e39, 8.27e7)   ,
new BlackHole("NGC 4395", "Galaxy with a relatively low-mass black hole", 3.6e35, 2.41e6)   ,
new BlackHole("GS 2000+25", "Black hole X-ray binary in the constellation Aquila", 1.34e33, 4.68e5) ,
new BlackHole("H1743-322", "Black hole X-ray binary in the constellation Scorpius", 2.56e31, 2.09e5)    ,
new BlackHole("SWIFT J1753.5-0127", "Black hole X-ray binary in the constellation Sagittarius", 1.86e32, 3.56e5)    ,
new BlackHole("IC 10 X-1", "Black hole X-ray binary in the dwarf galaxy IC 10", 5.09e33, 5.42e5)    ,
new BlackHole("GRS 1915+105", "Microquasar with a black hole in the constellation Aquila", 1.41e34, 9.52e5) ,
new BlackHole("M106", "Galaxy hosting a black hole in the constellation Canes Venatici", 4.79e39, 1.6e8)    ,
new BlackHole("NGC 300 X-1", "Black hole X-ray binary in the galaxy NGC 300", 2.54e35, 2.29e6)  ,
new BlackHole("LMC X-3", "Black hole X-ray binary in the Large Magellanic Cloud", 2.34e34, 8.58e5)  ,
new BlackHole("GRB 110328A", "Gamma-ray burst associated with a black hole", 2.39e34, 8.95e5)   ,
new BlackHole("MAXI J1659-152", "Black hole X-ray binary in the constellation Ara", 1.96e32, 3.29e5)    ,
new BlackHole("GRB 970508", "Gamma-ray burst associated with a black hole", 6.14e34, 1.03e6)    ,
new BlackHole("GRS 1124-68", "Black hole X-ray binary in the constellation Musca", 4.23e32, 4.27e5) ,
new BlackHole("LMC X-1", "Black hole X-ray binary in the Large Magellanic Cloud", 1.6e34, 7.59e5)   ,
new BlackHole("GRB 110709B", "Gamma-ray burst associated with a black hole", 3.68e34, 9.02e5)   ,
new BlackHole("GRS 1739-278", "Black hole X-ray binary in the constellation Scutum", 1.94e32, 3.45e5)   ,
new BlackHole("GRB 090926A", "Gamma-ray burst associated with a black hole", 5.73e34, 1.23e6)   ,
new BlackHole("GRB 110328B", "Gamma-ray burst associated with a black hole", 2.89e34, 8.68e5)   ,
new BlackHole("GRB 050525A", "Gamma-ray burst associated with a black hole", 4.09e34, 1.05e6)   ,
new BlackHole("Cyg X-3", "Black hole X-ray binary in the constellation Cygnus", 4.2e31, 2.07e5) ,
new BlackHole("GRB 050406", "Gamma-ray burst associated with a black hole", 5.49e34, 1.19e6)    ,
new BlackHole("GRB 090510", "Gamma-ray burst associated with a black hole", 3.47e34, 9.78e5)    ,
new BlackHole("GRB 050315", "Gamma-ray burst associated with a black hole", 2.36e34, 8.24e5)    ,
new BlackHole("GRB 130427A", "Gamma-ray burst associated with a black hole", 6.42e34, 1.34e6)   ,
new BlackHole("GRB 060729", "Gamma-ray burst associated with a black hole", 1.95e34, 6.95e5)    ,
new BlackHole("GRB 050318", "Gamma-ray burst associated with a black hole", 3.24e34, 9.32e5)    ,
new BlackHole("GRB 070809", "Gamma-ray burst associated with a black hole", 2.54e34, 7.58e5)    ,
new BlackHole("GRB 080319B", "Gamma-ray burst associated with a black hole", 1.88e34, 6.87e5)   ,
new BlackHole("GRB 050408", "Gamma-ray burst associated with a black hole", 2.89e34, 8.67e5)    ,
new BlackHole("GRB 091127", "Gamma-ray burst associated with a black hole", 1.73e34, 6.45e5)    ,
new BlackHole("GRB 060124", "Gamma-ray burst associated with a black hole", 3.09e34, 8.92e5)    ,
new BlackHole("GRB 100418A", "Gamma-ray burst associated with a black hole", 4.75e34, 1.11e6)   ,
new BlackHole("GRB 080319A", "Gamma-ray burst associated with a black hole", 2.63e34, 7.89e5)   ,
new Planet("Mercury", "Closest planet to the Sun", 3.3011e23, 2.4397e6) ,
new Planet("Venus", "Second planet from the Sun", 4.8675e24, 6.0518e6)  ,
new Planet("Earth", "Third planet from the Sun, our home", 5.97237e24, 6.371e6) ,
new Planet("Mars", "Fourth planet from the Sun, the Red Planet", 6.4171e23, 3.3895e6)   ,
new Planet("Jupiter", "Largest planet in our solar system", 1.8982e27, 6.9911e7)    ,
new Planet("Saturn", "Second-largest planet with prominent rings", 5.6834e26, 5.8232e7) ,
new Planet("Uranus", "Seventh planet from the Sun, tilted on its side", 8.6810e25, 2.5362e7)    ,
new Planet("Neptune", "Eighth planet from the Sun, known for its blue color", 1.02413e26, 2.4622e7) ,
new NaturalSatellite("Mercury's Moon", "Moon of Mercury", 3.3011e19, 1.737e6),
new NaturalSatellite("Venus's Moon", "Moon of Venus", 4.8675e21, 3.760e6),
new NaturalSatellite("Moon", "Earth's Moon", 7.342e22, 1.737e6),
new NaturalSatellite("Phobos", "Moon of Mars", 1.0659e16, 11.2667e3),
new NaturalSatellite("Deimos", "Moon of Mars", 1.4762e15, 6.2e3),
new NaturalSatellite("Io", "Moon of Jupiter", 8.9319e22, 1.8216e6),
new NaturalSatellite("Europa", "Moon of Jupiter", 4.7998e22, 1.561e6),
new NaturalSatellite("Ganymede", "Moon of Jupiter", 1.4819e23, 2.634e6),
new NaturalSatellite("Callisto", "Moon of Jupiter", 1.0759e23, 2.4103e6),
new NaturalSatellite("Mimas", "Moon of Saturn", 3.7493e19, 1.98e6),
new NaturalSatellite("Enceladus", "Moon of Saturn", 1.0802e20, 2.52e6),
new NaturalSatellite("Tethys", "Moon of Saturn", 6.1745e20, 5.33e6),
new NaturalSatellite("Dione", "Moon of Saturn", 1.095452e21, 5.62e6),
new NaturalSatellite("Rhea", "Moon of Saturn", 2.306518e21, 7.52e6),
new NaturalSatellite("Titan", "Moon of Saturn", 1.3452e23, 5.15e6),
new NaturalSatellite("Miranda", "Moon of Uranus", 6.59e19, 2.06e6),
new NaturalSatellite("Ariel", "Moon of Uranus", 1.353e21, 5.32e6),
new NaturalSatellite("Umbriel", "Moon of Uranus", 1.27e21, 5.37e6),
new NaturalSatellite("Titania", "Moon of Uranus", 3.527e21, 7.82e6),
new NaturalSatellite("Oberon", "Moon of Uranus", 3.014e21, 7.63e6),
new NaturalSatellite("Triton", "Moon of Neptune", 2.139e22, 2.707e6),
new Star("Sun", "Our closest star", StarType.MainSequence, 1.989e30, 6.9634e8)  ,
new Star("Sirius", "Brightest star in the night sky", StarType.MainSequence, 2.02e30, 1.71e9)   ,
new Star("Betelgeuse", "Red supergiant in the constellation Orion", StarType.Supergiant, 2.9e31, 8.6374e9)  ,
new Star("Vega", "Bright star in the constellation Lyra", StarType.MainSequence, 2.36e30, 2.362e9)  ,
new Star("Alpha Centauri A", "Closest star system to our solar system", StarType.MainSequence, 2.19e30, 1.594e9)    ,
new Star("Alpha Centauri B", "Companion star to Alpha Centauri A", StarType.MainSequence, 1.35e30, 1.082e9) ,
new Star("Proxima Centauri", "Closest known star to the Sun", StarType.MainSequence, 2.43e29, 1.511e8)  ,
new Star("Rigel", "Blue supergiant in the constellation Orion", StarType.Supergiant, 2.23e31, 6.324e9)  ,
new Star("Polaris", "North Star in the constellation Ursa Minor", StarType.MainSequence, 5.4e29, 7.586e8)   ,
new Star("Antares", "Red supergiant in the constellation Scorpius", StarType.Supergiant, 1.76e31, 6.685e9)  ,
new Star("Canopus", "Bright star in the constellation Carina", StarType.MainSequence, 8.028e30, 1.636e9)    ,
new Star("Arcturus", "Bright star in the constellation Boötes", StarType.MainSequence, 1.8e31, 2.978e9) ,
new Star("Aldebaran", "Bright star in the constellation Taurus", StarType.MainSequence, 3.96e30, 4.017e9)   ,
new Star("Altair", "Bright star in the constellation Aquila", StarType.MainSequence, 1.8e30, 1.845e9)   ,
new Star("Deneb", "Bright star in the constellation Cygnus", StarType.MainSequence, 1.4e32, 2.925e10)   ,
new Star("Regulus", "Bright star in the constellation Leo", StarType.MainSequence, 4.82e30, 3.751e9)    ,
new Star("Spica", "Bright star in the constellation Virgo", StarType.MainSequence, 1.06e31, 6.891e9)    ,
new Star("Pollux", "Bright star in the constellation Gemini", StarType.MainSequence, 1.8e31, 7.756e9)   ,
new Star("Fomalhaut", "Bright star in the constellation Piscis Austrinus", StarType.MainSequence, 1.92e30, 1.836e9) ,
new Star("Epsilon Eridani", "Closest star to the Sun within 10 light-years", StarType.MainSequence, 1.06e30, 1.747e9)   ,
new Star("Alnilam", "Bright star in the constellation Orion", StarType.Supergiant, 2.5e31, 9.562e9) ,
new Star("Bellatrix", "Bright star in the constellation Orion", StarType.MainSequence, 2.4e31, 6.678e9) ,
new Star("Achernar", "Bright star in the constellation Eridanus", StarType.MainSequence, 6.1e31, 1.779e9)   ,
new Star("Hamal", "Bright star in the constellation Aries", StarType.MainSequence, 2.12e31, 6.926e9)    ,
new Star("Mirfak", "Bright star in the constellation Perseus", StarType.MainSequence, 7.5e30, 5.179e9)  ,
new Star("Algol", "Binary star system in the constellation Perseus", StarType.Binary, 5.8e29, 3.626e8)  ,
new Star("Alderamin", "Bright star in the constellation Cepheus", StarType.MainSequence, 4.5e30, 3.418e9)   ,
new Star("Castor", "Binary star system in the constellation Gemini", StarType.Binary, 2.5e30, 2.66e9)   ,
new Star("Capella", "Binary star system in the constellation Auriga", StarType.Binary, 1.61e31, 1.906e9)    ,
new Star("Denebola", "Bright star in the constellation Leo", StarType.MainSequence, 2.3e31, 2.014e9)    ,
new Star("Pleiades", "Open star cluster in the constellation Taurus", StarType.Variable, 4.78e31, 1.161e10) ,
new Star("Alcyone", "Bright star in the Pleiades star cluster", StarType.MainSequence, 7.65e30, 3.03e9) ,
new Star("Atlas", "Binary star system in the Pleiades star cluster", StarType.Binary, 3.32e29, 1.14e8)  ,
new Star("Maia", "Bright star in the Pleiades star cluster", StarType.MainSequence, 5.8e30, 3.452e9)    ,
new Star("Merope", "Bright star in the Pleiades star cluster", StarType.MainSequence, 3.6e30, 2.705e9)  ,
new Star("Taygeta", "Bright star in the Pleiades star cluster", StarType.MainSequence, 3.9e30, 2.721e9) ,
new Star("Pleione", "Binary star system in the Pleiades star cluster", StarType.Binary, 2.6e30, 1.724e9)    ,
new Star("Hyades", "Open star cluster in the constellation Taurus", StarType.Variable, 7.9e31, 8.882e9) ,
new Star("Asterope", "Binary star system in the Pleiades star cluster", StarType.Binary, 2.5e30, 1.812e9)   ,
new Star("Electra", "Bright star in the Pleiades star cluster", StarType.MainSequence, 6.7e30, 3.906e9) ,
new Star("Celaeno", "Bright star in the Pleiades star cluster", StarType.MainSequence, 6.4e30, 3.621e9) ,
};

await repo.AddMany(objectList);
List<UniverseObject> universeObjectsList = await repo.GetAllUniverseObjects();
List<UniverseObject> universeObjectsListSortedByGravForce = universeObjectsList.OrderByDescending(universeObject => universeObject.SchwarzschildRadiusMeters).ToList();
foreach (UniverseObject universeObject in universeObjectsListSortedByGravForce)
{
    if (universeObject is Star)
    {
        WriteLine($"{universeObject.UniverseObjectType + " " + ((Star)universeObject).StarType,-20} | {universeObject.Name,-20}| Gravity Force: {universeObject.GravityForceN().ToString("E")} N | Radius : {universeObject.RadiusMeters.ToString("E"),-12} | SchwarzschildRadiusMeters {universeObject.SchwarzschildRadiusMeters.ToString("E")}");
    }
    else
    {
        WriteLine($"{universeObject.UniverseObjectType,-20} | {universeObject.Name,-20}| Gravity Force: {universeObject.GravityForceN().ToString("E")} N | Radius : {universeObject.RadiusMeters.ToString("E"),-12} | SchwarzschildRadiusMeters {universeObject.SchwarzschildRadiusMeters.ToString("E")}");
    }
}
#pragma warning disable CS8622 // Dopuszczanie wartości null dla typów referencyjnych w typie parametru nie jest zgodne z docelowym delegatem (prawdopodobnie z powodu atrybutów dopuszczania wartości null).
AppDomain.CurrentDomain.ProcessExit += LoggerConstants.CurrentDomain_ProcessExit;
#pragma warning restore CS8622 // Dopuszczanie wartości null dla typów referencyjnych w typie parametru nie jest zgodne z docelowym delegatem (prawdopodobnie z powodu atrybutów dopuszczania wartości null).









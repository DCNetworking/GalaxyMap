using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaxyMap.Models;
using GalaxyMap.Utilities;

namespace GalaxyMap.Contexts
{
    public class GalaxyMapContext
    {
        private static readonly Lazy<GalaxyMapContext> galaxyMapContext = new Lazy<GalaxyMapContext>(() => new GalaxyMapContext());
        /// <summary>
        /// Gets the list of universe objects in the galaxy map context.
        /// </summary>
        public readonly List<UniverseObject>? UniverseObjects;

        /// <summary>
        /// Gets the instance of the <see cref="GalaxyMapContext"/> class.
        /// </summary>
        public static GalaxyMapContext Init => galaxyMapContext.Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="GalaxyMapContext"/> class.
        /// </summary>
        private GalaxyMapContext()
        {
            UniverseObjects = new List<UniverseObject>();
        }
        public string Serialize()
        {
            throw new NotImplementedException();
        }

        public void Deserialize(string data)
        {
            throw new NotImplementedException();
        }
    }
}
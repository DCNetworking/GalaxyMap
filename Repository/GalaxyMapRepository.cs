using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using GalaxyMap.Contexts;
using GalaxyMap.Models;
using GalaxyMap.Utilities;
using Serilog;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace GalaxyMap.Repository
{
    public class GalaxyMapRepository : IGalaxyMapRepository
    {
        private readonly static Lazy<GalaxyMapRepository> galaxyMapRepository = new(() => new GalaxyMapRepository());
        private GalaxyMapContext _ctx = GalaxyMapContext.Init;
        private static ILogger? _logger;
        /// <summary>
        /// Initializes the galaxy map repository with a logger and returns an instance of <see cref="GalaxyMapRepository"/>.
        /// </summary>
        /// <param name="logger">The logger to be used for logging.</param>
        /// <returns>An instance of <see cref="GalaxyMapRepository"/>.</returns>
        public static GalaxyMapRepository InitRepo(ILogger logger)
        {
            _logger = logger;
            return galaxyMapRepository.Value;
        }
        public GalaxyMapRepository()
        {
            _logger?.Information("GalaxyMapRepository.Constructor | Initialized Repository {0}", nameof(GalaxyMapRepository));
        }
        public async Task<List<UniverseObject>>? GetAllUniverseObjects()
        {
            if (_ctx?.UniverseObjects is null)
            {
                _logger?.Error("GalaxyMapRepository.AddOne | {0} List is not defined in {1}", nameof(UniverseObject), nameof(GalaxyMapRepository));
                return new List<UniverseObject>();
            }
            List<UniverseObject> universeObjList = await Task.Run(() => _ctx.UniverseObjects);
            _logger?.Information("GalaxyMapRepository.GetAllUniverseObjects [{0}] bytes", universeObjList.GetListSize<UniverseObject>());
            return _ctx.UniverseObjects;
        }
        public async Task<UniverseObject> AddOne(UniverseObject universeObject)
        {
            if (_ctx is null || _ctx.UniverseObjects is null)
            {
                _logger?.Error("GalaxyMapRepository.AddOne | {0} List is not defined in {1}", nameof(UniverseObject), nameof(GalaxyMapRepository));
                return universeObject;
            }

            List<UniverseObject>? universeObjects = _ctx.UniverseObjects;
            int currentCount = universeObjects.Count;

            if (universeObjects.Where(uobj => uobj.Name == universeObject.Name).Any())
            {
                _logger?.Warning("GalaxyMapRepository.AddOne | UniverseObject({2}) : CONFLICT {0} - already exist in {1}.", universeObject.Name, nameof(GalaxyMapRepository), universeObject.GetType().Name);
                return universeObject;
            }

            await Task.Run(() => _ctx.UniverseObjects.Add(universeObject));

            int newCount = universeObjects.Count;
            if (newCount > currentCount)
            {
                _logger?.Information("GalaxyMapRepository.AddOne | UniverseObject({2}) : {0} Added successfully to {1}", universeObject.Name, nameof(GalaxyMapRepository), universeObject.GetType().Name);
                return universeObject;
            }
            else
            {
                _logger?.Warning("GalaxyMapRepository.AddOne |  UniverseObject({2}) : {0} Not added into List in {1}", universeObject.Name, nameof(GalaxyMapRepository), universeObject.GetType().Name);
            }

            return universeObject;
        }
        public async Task<List<UniverseObject>> AddMany(List<UniverseObject> universeObjects)
        {
            if (_ctx is null || _ctx.UniverseObjects is null)
            {
                _logger?.Error("GalaxyMapRepository.AddMany | {0} List is not defined in {1}", nameof(UniverseObject), nameof(GalaxyMapRepository));
                return universeObjects;
            }

            List<UniverseObject> currentUniverseObjects = _ctx.UniverseObjects;
            int currentCount = currentUniverseObjects.Count;
            _logger?.Information("GalaxyMapRepository.AddMany | [Process Started] with ({0}) count {1} List", currentCount, nameof(UniverseObject));

            if (universeObjects.Count == 0)
            {
                _logger?.Warning("GalaxyMapRepository.AddMany | UniverseObject({2}) : FAIL {0} - is empty {1}.", nameof(universeObjects), nameof(GalaxyMapRepository), universeObjects.GetType().Name);
                return universeObjects;
            }
            foreach (UniverseObject universeObject in universeObjects)
            {
                await AddOne(universeObject);
            }
            int newCount = currentUniverseObjects.Count;
            _logger?.Information("GalaxyMapRepository.AddMany | [Process Finished] {1}/{2} Objects has been added to {3} with new count : ({0})", newCount, newCount - currentCount, universeObjects.Count, nameof(UniverseObject));

            return universeObjects;
        }
        public async Task<List<UniverseObject>> GetUniverseObjectByName(string name)
        {
            List<UniverseObject> universeObjectByNameList = await Task.Run(() => _ctx.UniverseObjects.Where(universeObject => universeObject.Name.Contains(name)).ToList());
            _logger?.Information("GalaxyMapRepository.GetUniverseObjectByName param name=[{1}] results found:[{2}] [{0}] bytes", universeObjectByNameList.GetListSize<UniverseObject>(), name, universeObjectByNameList.Count);
            return universeObjectByNameList;
        }
    }
}
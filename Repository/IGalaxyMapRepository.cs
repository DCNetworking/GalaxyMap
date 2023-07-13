using GalaxyMap.Models;

namespace GalaxyMap.Repository
{
    public interface IGalaxyMapRepository
    {
        /// <summary>
        /// Adds a universe object to the repository.
        /// </summary>
        /// <param name="universeObject">The universe object to add.</param>
        /// <returns>A task representing the asynchronous operation. The task result is the added universe object.</returns>
        Task<UniverseObject>? AddOne(UniverseObject universeObject);

        /// <summary>
        /// Retrieves all universe objects from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation. The task result is a list of all universe objects.</returns>
        Task<List<UniverseObject>>? GetAllUniverseObjects();
    }
}
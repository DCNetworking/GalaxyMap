using System;
using System.Runtime.CompilerServices;


namespace GalaxyMap.Utilities
{
    /// <summary>
    /// Provides diagnostic utility methods.
    /// </summary>
    public static class DiagnosticService
    {
        /// <summary>
        /// Gets the total size of the elements in the specified list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The list to calculate the size for.</param>
        /// <returns>The total size in bytes of the elements in the list.</returns>
        public static int GetListSize<T>(this List<T> list)
        {
            int elementSize = Unsafe.SizeOf<T>();
            int count = list.Count;
            return elementSize * count;
        }
    }
}


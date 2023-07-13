using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace GalaxyMap.Utilities
{
    /// <summary>
    /// Provides mathematical utility methods.
    /// </summary>
    public static class MathService
    {
        /// <summary>
        /// Divides the numerator by the denominator, avoiding division by zero.
        /// </summary>
        /// <param name="numerator">The numerator value.</param>
        /// <param name="denominator">The denominator value.</param>
        /// <returns>The result of the division if the denominator is not zero; otherwise, returns 0.</returns>
        public static double DivideByZero(double numerator, double denominator)
        {
            return denominator == 0 ? 0 : numerator / denominator;
        }

        /// <summary>
        /// Calculates the Schwarzschild radius for the given mass in kilograms.
        /// </summary>
        /// <param name="massKg">The mass of the object in kilograms.</param>
        /// <returns>The Schwarzschild radius in meters.</returns>
        public static double SchwarzchildRadius(double massKg)
        {
            return (2 * PhysicalConstants.G * massKg) / (System.Math.Pow(PhysicalConstants.C, 2));
        }
    }
}
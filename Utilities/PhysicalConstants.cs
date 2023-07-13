using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyMap.Utilities
{
    public static class PhysicalConstants
    {
        /// <summary>
        /// The gravitational constant (G) in meters cubed per kilogram per second squared.
        /// </summary>
        public const double G = 0.0000000000667430;

        /// <summary>
        /// The speed of light (c) in meters per second.
        /// </summary>
        public const int C = 299_792_458;

        /// <summary>
        /// The mass of the Sun in kilograms.
        /// </summary>
        public const double SunMassKg = 1.989e30;
    }
}
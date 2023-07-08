using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalaxyMap.Utilities
{
    public static class MathService
    {
        public static double DivideByZero(double x, double y)
        {
            return y == 0 ? 0 : x / y;
        }
    }
}
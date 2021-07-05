using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSearchEngine.Helper
{
    public static class Engines
    {
        public const string Google = "google";
        public const string Bing = "bing";

        private static string[] EnginesArray { get; } = new[] { Google, Bing };
        public static bool IsValidEngine(string engine)
        {
            return EnginesArray.Contains(engine, StringComparer.OrdinalIgnoreCase);
        }
    }
}

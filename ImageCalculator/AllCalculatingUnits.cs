using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ImageCalculator
{
    public class AllCalculatingUnits
    {
        private static AllCalculatingUnits instance;
        private readonly Dictionary<string, CalculatingUnit> units;

        private AllCalculatingUnits()
        {
            units = Assembly.GetAssembly(typeof(CalculatingUnit)).GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(CalculatingUnit)))
                .Select(type => (CalculatingUnit)Activator.CreateInstance(type))
                .ToDictionary(unit => unit.GetName());
        }

        public static AllCalculatingUnits GetInstance() => instance ?? (instance = new AllCalculatingUnits());

        public CalculatingUnit GetUnit(string name) => units.ContainsKey(name) ?
            units[name] :
            throw new Exception($"Не удалось найти вычислительный узел для параметра \"{name}\".");
    }
}
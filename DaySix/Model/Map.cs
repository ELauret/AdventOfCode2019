using System;
using System.Collections.Generic;
using System.Linq;

namespace DaySix.Model
{
    public class Map
    {
        public List<Orbit> Orbits { get; set; }

        public Map(IEnumerable<string> map, string center)
        {
            Orbits = new List<Orbit>();

            foreach (var orbit in map)
            {
                AddOrbit(orbit);
            }

            var centralOrbit = Orbits.Find(o => o.Center == center);

            if (centralOrbit == null) throw new Exception($"{center} does not exist.");

            centralOrbit.Depth = 1;
            SetChildrenOrbitsDepth(centralOrbit);
        }

        private void AddOrbit(string orbitDescriptor)
        {
            var orbit = new Orbit(orbitDescriptor);
            Orbits.Add(orbit);
        }

        private void SetChildrenOrbitsDepth(Orbit parentOrbit)
        {
            var orbits = Orbits.FindAll(o => o.Center == parentOrbit.Object);

            if (orbits.Count != 0)
            {
                foreach (var orbit in orbits)
                {
                    orbit.Depth = parentOrbit.Depth + 1;
                    SetChildrenOrbitsDepth(orbit);
                }
            }
        }

        public int TotalNumberOfDirectAndIndirectOrbits()
        {
            return Orbits.Sum(o => o.Depth);
        }
    }
}

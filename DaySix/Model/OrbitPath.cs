using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DaySix.Model
{
    public class OrbitPath
    {
        public List<string> Nodes { get; set; }
        public static Map Map { get; set; }

        public OrbitPath(Map map)
        {
            if (Map == null) Map = map;
            Nodes = new List<string>();
        }

        public OrbitPath FromMapCenterTo(string nodeName)
        {
            var node = Map.Orbits.Find(o => o.Object == nodeName);

            if (node == null) throw new Exception($"Destination {nodeName} does not exist on the map.");

            var depth = node.Depth;

            while (depth > 1)
            {
                Nodes.Add(node.Center);
                node = Map.Orbits.Find(o => o.Object == node.Center);
                if (node == null) throw new Exception($"Node {nodeName} does not exist on the map.");
                depth = node.Depth;
            }

            return this;
        }
    }
}

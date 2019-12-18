﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FourLeggedHead.Tools
{
    public static class GraphSolver
    {

        #region BFS Algorithm

        /// <summary>
        /// Explore all levels of the graph until the desired vertex is found
        /// </summary>
        /// <param name="graph"> Graph to search within </param>
        /// <param name="origin"> Starting vertex in the graph for the search </param>
        /// <param name="target"> Vertex to look for </param>
        /// <returns></returns>
        public static HashSet<IVertex> BreadthFirstSearch(IGraph graph, IVertex origin, IVertex target)
        {
            if (!graph.Contains(origin)) return null;
            if (target != null && !graph.Contains(target)) return null;

            var visited = new HashSet<IVertex>();

            var queue = new Queue<IVertex>();
            queue.Enqueue(origin);

            while (queue.Any())
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex)) continue;

                visited.Add(vertex);

                if (target != null && vertex == target) return visited;

                foreach (var neighbor in graph.GetNeighbors(vertex))
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        neighbor.Parent = vertex;
                    }
                }
            }

            return visited;
        }
        
        /// <summary>
        /// Explore the entire graph, level by level
        /// </summary>
        /// <param name="graph"> Graph to explore </param>
        /// <param name="origin"> Starting vertex in the graph for its exploration </param>
        /// <returns></returns>
        public static HashSet<IVertex> BreadthFirstExploration(IGraph graph, IVertex origin)
        {
            return BreadthFirstSearch(graph, origin, null);
        }

        #endregion

        #region DFS Algortihm

        /// <summary>
        /// Explore the graph depth first, recursively
        /// </summary>
        /// <param name="graph"> Graph to explore </param>
        /// <param name="origin"> Starting vertex in the graph for its exploration </param>
        /// <returns></returns>
        public static HashSet<IVertex> DepthFirstSearchRecursive(IGraph graph, IVertex origin)
        {
            var visited = new HashSet<IVertex>();
            DepthFirstTraverse(graph, visited, origin);
            return visited;
        }

        private static void DepthFirstTraverse(IGraph graph, HashSet<IVertex> visited, IVertex vertex)
        {
            if (!graph.Contains(vertex)) return;

            visited.Add(vertex);

            foreach (var neighbor in graph.GetNeighbors(vertex))
            {
                if (!visited.Contains(neighbor))
                {
                    DepthFirstTraverse(graph, visited, neighbor);
                }
            }
        }

        /// <summary>
        /// Explore entire branches of the graph until the desired vertex is found
        /// </summary>
        /// <param name="graph"> Graph to search within </param>
        /// <param name="origin"> Starting vertex in the graph for the search </param>
        /// <param name="target"> Vertex to look for </param>
        /// <returns></returns>
        private static HashSet<IVertex> DepthFirstSearchIterative(IGraph graph, IVertex origin, IVertex target)
        {
            if (!graph.Contains(origin)) return null;
            if (target != null && !graph.Contains(target)) return null;

            var visited = new HashSet<IVertex>();

            var stack = new Stack<IVertex>();
            stack.Push(origin);

            while (stack.Any())
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex)) continue;

                visited.Add(vertex);

                if (target != null && vertex == target) return visited;

                foreach (var neighbor in graph.GetNeighbors(vertex))
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                        neighbor.Parent = vertex;
                    }
                }
            }

            return visited;
        }

        /// <summary>
        /// Explore the graph depth first, iteratively
        /// </summary>
        /// <param name="graph"> Graph to explore </param>
        /// <param name="origin"> Starting vertex in the graph for its exploration </param>
        /// <returns></returns>
        public static HashSet<IVertex> DepthFirstExploration(IGraph graph, IVertex origin)
        {
            return DepthFirstSearchIterative(graph, origin, null);
        }

        #endregion

        #region Dijkstra Algorithm

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graph"></param>
        /// <param name="origin"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Dictionary<IVertex,T> GetShortestPathDijkstra<T>(IGraph graph, IVertex origin, IVertex target)
            where T : struct, IEquatable<T>, IComparable<T>
        {
            if (!graph.Contains(origin)) return null;
            if (target != null && !graph.Contains(target)) return null;

            var queue = new Queue<IVertex>(graph);

            var vertices = new Dictionary<IVertex, T>();
            foreach (var vertex in queue)
            {
                vertex.Parent = null;
                vertices.Add(vertex, graph.MaxDistance<T>());
            }

            vertices[origin] = origin.DistanceTo<T>(origin);

            while (queue.Any())
            {
                var vertex = queue.Dequeue();

                if (target != null && vertex == target) return vertices;

                foreach (var neighbor in graph.GetNeighbors(vertex))
                {
                    var distance = graph.AddDistance<T>(vertices[vertex], neighbor.DistanceTo<T>(vertex));

                    if (distance.CompareTo(vertices[neighbor]) < 0)
                    {
                        neighbor.Parent = vertex;
                        vertices[neighbor] = distance;
                    }
                }
            }

            return vertices;
        }

        #endregion
    }
}

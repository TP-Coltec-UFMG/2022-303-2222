using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generator {
    public class Maze {
        public int[,] map;
        public Coordinate entry { get; }
        public Coordinate exit { get; }

        public Maze(int[,] map, Coordinate entry, Coordinate exit) {
            this.map = map;
            this.entry = entry;
            this.exit = exit;
        }

        public List<Coordinate> FindPath(Coordinate enter, Coordinate exit) {
            HashSet<Coordinate> visitedCoordinates = new HashSet<Coordinate>();
            Queue<Coordinate> queue = new Queue<Coordinate>();
            Dictionary<Coordinate, Coordinate> predecessors = new Dictionary<Coordinate, Coordinate>();
            LinkedList<Coordinate> path = new LinkedList<Coordinate>();

            queue.Enqueue(enter);
            while (queue.Count > 0 || !visitedCoordinates.Contains(exit)) {
                Coordinate current = queue.Dequeue();
                List<Coordinate> adjacentCoordinates = current.GetAdjcentCoordinates
                    (map.GetLength(0), map.GetLength(1));

                foreach (Coordinate coordinate in adjacentCoordinates) {
                    if (!visitedCoordinates.Contains(coordinate)) {
                        predecessors.Add(coordinate, current);
                        queue.Enqueue(coordinate);
                    }
                }
                visitedCoordinates.Add(current);
            }

            if (visitedCoordinates.Contains(exit)) {
                Coordinate current = exit;
                while (current.Equals(enter)) {
                    path.AddFirst(current);
                    current = predecessors[current];
                }
                path.AddFirst(enter);
            }

            return path.ToList();
        }
    }
}

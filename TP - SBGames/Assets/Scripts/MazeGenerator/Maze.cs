using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generator
{
    public class Maze
    {
        public int[,] map;
        public Coordinate exit;
        public Maze(int[,] map, Coordinate exit) {
            this.map = map;
            this.exit = exit;
        }
    }
}

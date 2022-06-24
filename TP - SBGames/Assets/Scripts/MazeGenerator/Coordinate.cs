using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Generator
{
    public class Coordinate
    {
         public int x { get; }
         public int y { get; }

         public Coordinate(int x, int y)
         {
             this.x = x;
             this.y = y;
         }

         private List<Coordinate> GetAdjcentCoordinates(int maxWidth, int maxHeight)
         {
            List<Coordinate> adjacentCoordinates = new List<Coordinate>();

            if (x + 1 >= 0 && x + 1 < maxWidth && y >= 0 && y < maxHeight)
            {
                adjacentCoordinates.Add(new Coordinate(x + 1, y));
            }
            if (x - 1 >= 0 && x - 1 < maxWidth && y >= 0 && y < maxHeight)
            {
                adjacentCoordinates.Add(new Coordinate(x - 1, y));
            }
            if (x >= 0 && x < maxWidth && y + 1 >= 0 && y + 1 < maxHeight)
            {
                adjacentCoordinates.Add(new Coordinate(x, y + 1));
            }
            if (x >= 0 && x < maxWidth && y - 1 >= 0 && y - 1 < maxHeight) 
            {
                adjacentCoordinates.Add(new Coordinate(x, y - 1));
            }

            return adjacentCoordinates;
         }

         public List<Coordinate> GetUnvisitedAdjacentCoordinates(int maxWidth, int maxHeight, HashSet<Coordinate> visitedCoordinates)
         {
             List<Coordinate> adjacentCoordinates = GetAdjcentCoordinates(maxWidth, maxHeight);
             List<Coordinate> unvisitedAdjacentCoordinates = new List<Coordinate>();

             unvisitedAdjacentCoordinates = adjacentCoordinates
                 .Where(c => !visitedCoordinates.Contains(c)).ToList();
             return unvisitedAdjacentCoordinates;
         }

         public override bool Equals(object? obj)
         {
             if (obj == null || this.GetType() != obj.GetType())
             {
                 return false;
             }
             else
             {
                 Coordinate coordinate = (Coordinate) obj;
                 return x == coordinate.x && y == coordinate.y;
             }
         }

         public override int GetHashCode()
         {
            int X = x >= 0 ? 2 * x : -2 * x - 1;
            int Y = y >= 0 ? 2 * y : -2 * y - 1;
            return X >= Y ? X * X + X + Y : X + Y * Y;
         }
    }
}

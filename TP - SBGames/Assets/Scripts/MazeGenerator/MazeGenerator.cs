using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Maze_Generator
{
    public class MazeGenerator
    {
        private int width;
        private int height;
        private  Random random;
        private readonly int maxNumberOfCoordinates;
        
        private const int MAZE_CELL_SIZE = 2;
        private const int WALL_SIZE = 1;

        private const int WALL = 1;
        private const int PASSAGE = 0;

        public MazeGenerator(int width, int height)
        {
            if (width <= 1 || height <= 1) {
                throw new ArgumentException("Width and/or height should be higher than 1");
            }
            this.width = width;
            this.height = height;
            maxNumberOfCoordinates = height * width; 
            random = new Random();
        }

        public int[,] GenerateMaze()
        {
            int[,] maze = InitMaze();
            List<Tuple<Coordinate, Coordinate>> mazePath = BackTracking();

            foreach (Tuple<Coordinate, Coordinate> value in mazePath)
            {
               BreakWall(maze, value.Item1, value.Item2); 
            }
            return maze;
        }

        private int[,] InitMaze()
        {
            int[,] maze = new int[(width * MAZE_CELL_SIZE) + WALL_SIZE * (width - 1) + MAZE_CELL_SIZE, (height * MAZE_CELL_SIZE) + (height - 1) * WALL_SIZE + MAZE_CELL_SIZE];

            // Setting all the internal walls between the cells of the maze 
            for (int i = WALL_SIZE * 2 + 1; i < maze.GetLength(0) - WALL_SIZE; i += 3)
            {
                for (int j = WALL_SIZE; j < maze.GetLength(1); j++)
                {
                    maze[i, j] = WALL;
                    maze[j,i] = WALL;
                }
            }

            // Setting all the external walls of the maze 
            for (int i = 0; i < maze.GetLength(0); i += maze.GetLength(0) - 1)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i, j] = WALL;
                    maze[j, i] = WALL;
                }               
            }
            return maze;
        }

        private void BreakWall(int[,] maze, Coordinate a, Coordinate b)
        {
            int aX = a.x * (MAZE_CELL_SIZE + 1) + 1;
            int aY = a.y * (MAZE_CELL_SIZE + 1) + 1;
            int bX = b.x * (MAZE_CELL_SIZE + 1) + 1;
            int bY = b.y * (MAZE_CELL_SIZE + 1) + 1;

            if (aY < bY)
            {
                for (int i = aX ; i < aX + MAZE_CELL_SIZE; i++)
                {
                    maze[i, bY - 1] = PASSAGE;
                }
            }
            else if (aY > bY)
            {
                for (int i = aX ; i < aX + MAZE_CELL_SIZE; i++)
                {
                    maze[i, aY - 1] = PASSAGE;
                }
            }
            else if (aX < bX)
            {
                for (int i = aY; i < aY + MAZE_CELL_SIZE; i++)
                {
                   maze[bX - 1, i] = PASSAGE;
                }
            }
            else
            {
                for (int i = aY; i < aY + MAZE_CELL_SIZE; i++)
                {
                   maze[aX - 1, i] = PASSAGE;
                }               
            }
        }

        private List<Tuple<Coordinate, Coordinate>> BackTracking()
        {
            List<Tuple<Coordinate, Coordinate>> mazePath = new List<Tuple<Coordinate, Coordinate>>();
            HashSet<Coordinate> visited = new HashSet<Coordinate>();
            Stack<Coordinate> stack = new Stack<Coordinate>();
            List<Coordinate> adjacentCoordinates;

            Coordinate initialCoordinate = GenerateInitialCoordinate();
            visited.Add(initialCoordinate);
            stack.Push(initialCoordinate);

            Coordinate last = initialCoordinate;
            adjacentCoordinates = initialCoordinate.GetUnvisitedAdjacentCoordinates(width, height, visited); 

            while (visited.Count < width * height)
            {
                Coordinate current = adjacentCoordinates[random.Next(adjacentCoordinates.Count)];
                visited.Add(current);
                adjacentCoordinates = current.GetUnvisitedAdjacentCoordinates(width, height, visited);

                bool backtrack = false;
                // Store a wall to break, in the path of the maze
                mazePath.Add(new Tuple<Coordinate, Coordinate>(last, current));                
                last = current;

                // If a node does not have unvisited adjacent nodes, backtrack
                while (adjacentCoordinates.Count == 0 && stack.Count > 0)
                {
                    Coordinate lastVisitedCoordinate = stack.Pop();
                    last = lastVisitedCoordinate;
                    adjacentCoordinates = lastVisitedCoordinate.GetUnvisitedAdjacentCoordinates(width, height, visited);
                    backtrack = true;
                }
                if (backtrack) continue;
                stack.Push(current);
            }
            return mazePath;
        }

        private Coordinate GenerateInitialCoordinate()
        {
            // The initial coordinates are in the "border" of the maze
            List<Coordinate> possibleInitialCoordinates = new List<Coordinate>();

            for (int i = 0; i < width; i += width - 1)
            {
                for (int j = 0; j < height; j++)
                {
                   possibleInitialCoordinates.Add(new Coordinate(i,j)); 
                    possibleInitialCoordinates.Add(new Coordinate(j,i));
                } 
            }
            return possibleInitialCoordinates[random.Next(possibleInitialCoordinates.Count)];
        }
    }
}

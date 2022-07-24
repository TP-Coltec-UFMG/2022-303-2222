using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
namespace Maze_Generator {
    public class TilemapMazeGenerator : MonoBehaviour {
        public Tilemap groundTilemap;
        public Tilemap wallTilemap;
        public Tile wallTile;
        public Tile groundTile;
        public GameObject exitObject;
        [Range(1, 200)]
        public int tilemapDimension;
        private int realHeightOfTilemap;
        private int realWidthOfTilemap;
        private const int WALL = 1;
        private const int MAZE_CELL_SIZE = 2;
        private const int WALL_SIZE = 1;
        private Maze maze;
        private Vector3Int tilemapSize;
        [SerializeField] private GameObject player;

        private void Start()
        {
            ClearMaze();
            GenerateTileMapMaze();
            exitObject.transform.parent = null;
        } 
        
        public void ClearMaze()
        {
            wallTilemap.ClearAllTiles();
            groundTilemap.ClearAllTiles();
        }
        
        public void GenerateTileMapMaze() {
            tilemapSize = new Vector3Int(tilemapDimension, tilemapDimension, 0);
            realWidthOfTilemap = (tilemapSize.x * MAZE_CELL_SIZE) + WALL_SIZE * (tilemapSize.x - 1) + MAZE_CELL_SIZE;
            realHeightOfTilemap = (tilemapSize.y * MAZE_CELL_SIZE) + (tilemapSize.y - 1) * WALL_SIZE + MAZE_CELL_SIZE;
            maze = GenerateMaze();
            int [,] tiles = maze.map;
            for (int i = 0; i < realWidthOfTilemap; i++) {
                for (int j = 0; j < realHeightOfTilemap; j++) {
                    if (tiles[i, j] == WALL) {
                        wallTilemap.SetTile(new Vector3Int(j, -i, 0), wallTile);
                    }
                    else {
                        groundTilemap.SetTile(new Vector3Int(j , -i, 0), groundTile);
                    }
                }
            }
            player.transform.position = new Vector3((float)maze.entry.y + 0.5f, (float)-maze.entry.x + 0.5f, 0);
            exitObject.transform.position = new Vector3((float) maze.exit.y + 0.5f, (float) -maze.exit.x + 0.5f, 0);
        }

        private Maze GenerateMaze() {
            MazeGenerator mazeGenerator = new MazeGenerator(tilemapSize.x, tilemapSize.y);
            return mazeGenerator.GenerateMaze();
        }
    }

}

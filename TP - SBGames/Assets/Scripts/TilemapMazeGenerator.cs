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
        [Range(1, 200)]
        public int tilemapDimension;
        private int realHeightOfTilemap;
        private int realWidthOfTilemap;
        private int[,] tiles;
        private const int WALL = 1;
        private const int MAZE_CELL_SIZE = 2;
        private const int WALL_SIZE = 1;
        private Vector3Int tilemapSize;

        private void Start() {
            GenerateTileMapMaze();
        }
        public void GenerateTileMapMaze() {
            tilemapSize = new Vector3Int(tilemapDimension, tilemapDimension, 0);
            realWidthOfTilemap = (tilemapSize.x * MAZE_CELL_SIZE) + WALL_SIZE * (tilemapSize.x - 1) + MAZE_CELL_SIZE;
            realHeightOfTilemap = (tilemapSize.y * MAZE_CELL_SIZE) + (tilemapSize.y - 1) * WALL_SIZE + MAZE_CELL_SIZE;
            tiles = GenerateMaze();
            for (int i = 0; i < realWidthOfTilemap; i++) {
                for (int j = 0; j < realHeightOfTilemap; j++) {
                    if (tiles[i, j] == WALL) {
                        wallTilemap.SetTile(new Vector3Int(-i + (tilemapSize.x / 2), -j + (tilemapSize.y / 2), 0), wallTile);
                    }
                    else {
                        groundTilemap.SetTile(new Vector3Int(-i + tilemapSize.x / 2, -j + tilemapSize.y / 2, 0), groundTile);
                    }
                }
            }
        }

        private int[,] GenerateMaze() {
            MazeGenerator mazeGenerator = new MazeGenerator(tilemapSize.x, tilemapSize.y);
            int[,] maze = mazeGenerator.GenerateMaze();
            return maze;
        }
    }

}

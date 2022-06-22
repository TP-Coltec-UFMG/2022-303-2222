using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
namespace Maze_Generator {
    public class TilemapMazeGenerator : MonoBehaviour {
        public Tilemap groundTileMap;
        public Tilemap wallTileMap;
        public Tile wallTile;
        public Tile groundTile;
        private int realHeightOfTileMap;
        private int realWidthOfTileMap;
        private int[,] tiles;
        private const int WALL = 1;
        private const int MAZE_CELL_SIZE = 2;
        private const int WALL_SIZE = 1;
        private Vector3Int TilemapSize;
        public int TilemapDimension;
        private void Start() {
            makeMaze();
        }
        private void makeMaze() {
            TilemapSize = new Vector3Int(TilemapDimension, TilemapDimension, 0);
            realWidthOfTileMap = (TilemapSize.x * MAZE_CELL_SIZE) + WALL_SIZE * (TilemapSize.x - 1) + MAZE_CELL_SIZE;
            realHeightOfTileMap = (TilemapSize.y * MAZE_CELL_SIZE) + (TilemapSize.y - 1) * WALL_SIZE + MAZE_CELL_SIZE;
            if (tiles == null) {
                tiles = generateMaze();
            }                   
            for (int i = 0; i < realWidthOfTileMap; i++) {
                for (int j = 0; j < realHeightOfTileMap; j++) {
                    if (tiles[i, j] == WALL) {
                        wallTileMap.SetTile(new Vector3Int(-i + (TilemapSize.x / 2), -j + (TilemapSize.y / 2), 0), wallTile);
                    }
                    else {
                        groundTileMap.SetTile(new Vector3Int(-i + TilemapSize.x / 2, -j + TilemapSize.y / 2, 0), groundTile);
                    }
                }
            }
        }

        private int[,] generateMaze() {
            MazeGenerator mazeGenerator = new MazeGenerator(TilemapSize.x, TilemapSize.y);
            int[,] maze = mazeGenerator.GenerateMaze();
            return maze;
        }
    }

}

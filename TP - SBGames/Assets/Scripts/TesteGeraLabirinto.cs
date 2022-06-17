using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TesteGeraLabirinto : MonoBehaviour
{
public Tilemap groundTileMap;
    public Tilemap wallTileMap;
    public Tile wallTile;
    public Tile groundTile;
    private int heightOfTileMap;
    private int widthOfTileMap;
    private int[,] tiles;
    public Vector3Int TilemapSize;
    public int[,] startTileCoordinates;
    public int TilemapDimension;
    private void Start() {
        makeMaze();
    }
    private void makeMaze() {
        int wall = 1;
        TilemapSize = new Vector3Int(TilemapDimension, TilemapDimension, 0);
        widthOfTileMap = TilemapSize.x;
        heightOfTileMap = TilemapSize.y;
        if (tiles == null) {
            tiles = new int[heightOfTileMap, widthOfTileMap];
            tiles = generateRandomMatrice(tiles);
        }
        for (int i = 0; i < heightOfTileMap; i++) {
            for (int j = 0; j < widthOfTileMap; j++) {
                if (tiles[i,j] == wall) {
                    wallTileMap.SetTile(new Vector3Int(-i + (widthOfTileMap / 2), -j + (heightOfTileMap / 2), 0), wallTile);
                    
                }
                else {
                    groundTileMap.SetTile(new Vector3Int(-i + widthOfTileMap / 2, -j + heightOfTileMap / 2, 0), groundTile);
                }
            }
        }
    }

    private int[,] generateRandomMatrice(int[,] tiles) {
        for (int i = 0; i < heightOfTileMap; ++i) {
            for (int j = 0; j < widthOfTileMap; ++j) {
                tiles[i, j] = Random.Range(0, 2);
            }
        }
        return tiles;
    }
}

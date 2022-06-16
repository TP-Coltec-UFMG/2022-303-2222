using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void makeMaze() {
        widthOfTileMap = TilemapSize.x;
        heightOfTileMap = TilemapSize.y;
        if (tiles == null) {
            tiles = new int[heightOfTileMap, widthOfTileMap];
        }

    }
    public int[] getStartTile() {
        int[] startPosition = new int[2];
        startPosition[0] = Random.RandomRange(0, heightOfTileMap);
        startPosition[1] = Random.RandomRange(0, widthOfTileMap);
        return startPosition;
    }
}

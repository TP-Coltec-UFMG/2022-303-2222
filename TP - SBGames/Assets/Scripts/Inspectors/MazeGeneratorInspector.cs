using UnityEngine;
using UnityEditor;

namespace Maze_Generator
{
    [CustomEditor(typeof(TilemapMazeGenerator))]
    public class MazeGeneratorInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            TilemapMazeGenerator tilemapMazeGenerator = (TilemapMazeGenerator)target;
            base.OnInspectorGUI();

            if (GUILayout.Button("Generate Maze"))
            {
                tilemapMazeGenerator.wallTilemap.ClearAllTiles();
                tilemapMazeGenerator.groundTilemap.ClearAllTiles();                    
                tilemapMazeGenerator.GenerateTileMapMaze();
            }

            if(GUILayout.Button("Clear Maze"))
            {
                tilemapMazeGenerator.wallTilemap.ClearAllTiles();
                tilemapMazeGenerator.groundTilemap.ClearAllTiles();
            }
        }
    }
}

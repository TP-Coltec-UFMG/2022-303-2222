using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
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
                tilemapMazeGenerator.ClearMaze();
                tilemapMazeGenerator.GenerateTileMapMaze();
            }

            if(GUILayout.Button("Clear Maze"))
            {
                tilemapMazeGenerator.ClearMaze();
            }
        }
    }
}
#endif
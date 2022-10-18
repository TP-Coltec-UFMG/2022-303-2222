using Maze_Generator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSound : MonoBehaviour
{
    AudioSource exitAudio;
    [SerializeField] TilemapMazeGenerator tilemapMazeGenerator;
    public static bool exitMaze = false;
    void Start() 
    {
        exitAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (exitMaze)
        {
            exitMaze = false;
            if (!exitAudio.isPlaying) exitAudio.Play();
            tilemapMazeGenerator.GenerateNextLevelMaze();
        }
    }
}

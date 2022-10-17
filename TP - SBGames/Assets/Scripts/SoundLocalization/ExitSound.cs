using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSound : MonoBehaviour
{
    AudioSource exitAudio;
    public static bool exitMaze = false;
    void Start() 
    {
        exitAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (exitMaze)
        {
            if(!exitAudio.isPlaying) exitAudio.Play();
            Debug.Log("SAIU");

            exitMaze = false;
        }
    }
}

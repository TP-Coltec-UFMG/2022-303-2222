using System.Collections;
using System.Collections.Generic;
using Maze_Generator;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialExitSound : MonoBehaviour
{
    AudioSource exitAudio;
    public static bool exitMaze = false;
    private GameObject player;
    private Stack<Vector2> tutorialLevelsPositions;

    void Start()
    {
        exitAudio = GetComponent<AudioSource>();
        tutorialLevelsPositions = new Stack<Vector2>(new Vector2[]{new (58.5f, 4.5f), new (27.5f, 4.5f), new (1.5f, 4.5f)});
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (exitMaze)
        {
            exitMaze = false;
            if (!exitAudio.isPlaying) exitAudio.Play();
            
            // TODO -> Animar a mudanca de posicao. Ficou tipo um TP, uma bosta ...
            if (tutorialLevelsPositions.Count > 0)
            {
                player.transform.position = tutorialLevelsPositions.Pop();
            }
            
            // TODO -> MUDAR O AUDIO (TOCAR ALGO COMO SE FOSSE, O JOGO COMECOU !!!)
            else SceneManager.LoadScene("Primeira_Fase");
        }
    }
}
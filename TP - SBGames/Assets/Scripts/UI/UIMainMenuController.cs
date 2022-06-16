using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenuController : UIGenericMenu
{
    public void StartGame(string nextSceneName)
    {
        Debug.Log("Iniciou o jogo");
        // SceneManager.LoadScene(nextSceneName);
    }
    
    public void OpenOptionsMenu(GameObject optionsMenu)
    {
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }

}

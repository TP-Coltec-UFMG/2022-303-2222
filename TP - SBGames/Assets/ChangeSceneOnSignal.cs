using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnSignal : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

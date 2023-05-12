using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class ExitScenes : MonoBehaviour
{
    private StreamWriter sw;

    public static void ExitScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void EndGame()
    {
        
        Application.Quit();
    }
}

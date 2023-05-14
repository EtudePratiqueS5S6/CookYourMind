using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float gameDuration; // 10 minutes in seconds
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= gameDuration)
        {
            // Arr�ter la partie
            Debug.Log("Temps �coul� !");
            ExitScenes.ExitScene("Fin");
        }
    }
}

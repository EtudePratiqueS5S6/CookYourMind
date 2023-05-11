using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimerDifficulty2 : MonoBehaviour
{
    public float gameDuration = 600f; // 10 minutes in seconds
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= gameDuration)
        {
            // Arrêter la partie
            Debug.Log("Temps écoulé !");
            Time.timeScale = 0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDisappearing : MonoBehaviour
{
    private int time;
    private int event1;

    void Awake()
    {
        //temps d'attentre avant la disparition initialis� avant le lancement de la sc�ne
        time = (int)Time.time;
        event1 = 180;
    }
    

    void Update()
    {
        time = (int)Time.time;
        if (time == event1)
        {
            //quand on arrive � la fin du timer plus de recette
            gameObject.SetActive(false);
            Debug.Log("Plus de recette");
        }
    }

}

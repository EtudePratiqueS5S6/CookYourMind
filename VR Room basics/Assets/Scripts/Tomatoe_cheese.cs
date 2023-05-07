using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomatoe_cheese : MonoBehaviour
{
    public GameObject disqueSauceTomate;
    public Transform socketPatePizza;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PatePizza"))
        {
            gameObject.SetActive(false);
            Vector3 pos = gameObject.transform.position;
            disqueSauceTomate.transform.position = pos;
            disqueSauceTomate.SetActive(true);
            
        }
    }
}

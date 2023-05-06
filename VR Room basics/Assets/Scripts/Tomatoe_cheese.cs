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
            disqueSauceTomate.SetActive(true);
            disqueSauceTomate.transform.SetParent(socketPatePizza);
            disqueSauceTomate.transform.localPosition = Vector3.zero;
        }
    }
}

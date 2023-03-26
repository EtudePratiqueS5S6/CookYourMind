using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject choppedVegetable;
    void Update()
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("knife"))
            {
                gameObject.SetActive(false);
                choppedVegetable.SetActive(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidKnifeSocket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Knife"))
        {
            Debug.Log(string.Format("ajout couteau"));
            ValidSetTable.IncreaseCutleryPlaced();
        }
    }
}

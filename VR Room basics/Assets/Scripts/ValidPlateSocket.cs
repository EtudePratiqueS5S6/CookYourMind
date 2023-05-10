using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidPlateSocket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plate"))
        {
            Debug.Log(string.Format("ajout assiette"));
            ValidSetTable.IncreaseCutleryPlaced();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Plate"))
        {
            Debug.Log(string.Format("ajout assiette"));
            ValidSetTable.DecreaseCutleryPlaced();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidGlassSocket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Glass"))
        {
            Debug.Log(string.Format("ajout verre"));
            ValidSetTable.IncreaseCutleryPlaced();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Glass"))
        {
            Debug.Log(string.Format("ajout verre"));
            ValidSetTable.DecreaseCutleryPlaced();
        }
    }
}

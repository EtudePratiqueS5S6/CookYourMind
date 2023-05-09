using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidForkSocket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fork"))
        {
            Debug.Log(string.Format("ajout fourchette"));
            ValidSetTable.IncreaseCutleryPlaced();
        }
    }
}

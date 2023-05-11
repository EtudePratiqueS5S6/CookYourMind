using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidyIncrDifficulty3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untidy"))
        {
            TidyDifficulty3.IncrNbrObject();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Untidy"))
        {
            TidyDifficulty3.DesincrNbrObject();
        }

    }
}

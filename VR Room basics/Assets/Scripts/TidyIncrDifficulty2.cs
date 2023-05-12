using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidyIncrDifficulty2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untidy"))
        {
            TidyDifficulty2.IncrNbrObject();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Untidy"))
        {
            TidyDifficulty2.DesincrNbrObject();
        }

    }
}

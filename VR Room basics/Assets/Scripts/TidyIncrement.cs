using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidyIncrement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Untidy"))
        {
            Tidy.IncrNbrObject();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Untidy"))
        {
            Tidy.DesincrNbrObject();
        }
        
    }
}

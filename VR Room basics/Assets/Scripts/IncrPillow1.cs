using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrPillow1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pillow2"))
        {
            TidyDifficulty3.IncrNbrObject();
        }
        if (other.CompareTag("Pillow3"))
        {
            TidyDifficulty3.IncrNbrObject();
        }
        if (other.CompareTag("Pillow4"))
        {
            TidyDifficulty3.IncrNbrObject();
        }
        if (other.CompareTag("Pillow1"))
        {
            TidyDifficulty3.IncrNbrObject();
            TidyDifficulty3.IncrNbrPillow();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pillow2"))
        {
            TidyDifficulty3.DesincrNbrObject();
        }
        if (other.CompareTag("Pillow3"))
        {
            TidyDifficulty3.DesincrNbrObject();
        }
        if (other.CompareTag("Pillow4"))
        {
            TidyDifficulty3.DesincrNbrObject();
        }
        if (other.CompareTag("Pillow1"))
        {
            TidyDifficulty3.DesincrNbrObject();
            TidyDifficulty3.DesincrNbrPillow();
        }

    }
}

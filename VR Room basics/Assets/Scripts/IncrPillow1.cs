using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrPillow1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pillow2"))
        {
            Tidy.IncrNbrObject();
        }
        if (other.CompareTag("Pillow3"))
        {
            Tidy.IncrNbrObject();
        }
        if (other.CompareTag("Pillow4"))
        {
            Tidy.IncrNbrObject();
        }
        if (other.CompareTag("Pillow1"))
        {
            Tidy.IncrNbrObject();
            Tidy.IncrNbrPillow();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pillow2"))
        {
            Tidy.DesincrNbrObject();
        }
        if (other.CompareTag("Pillow3"))
        {
            Tidy.DesincrNbrObject();
        }
        if (other.CompareTag("Pillow4"))
        {
            Tidy.DesincrNbrObject();
        }
        if (other.CompareTag("Pillow1"))
        {
            Tidy.DesincrNbrObject();
            Tidy.DesincrNbrPillow();
        }

    }
}

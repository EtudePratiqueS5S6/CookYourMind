using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncrPillow3 : MonoBehaviour
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
            Tidy.IncrNbrPillow();
        }
        if (other.CompareTag("Pillow4"))
        {
            Tidy.IncrNbrObject();
        }
        if (other.CompareTag("Pillow1"))
        {
            Tidy.IncrNbrObject();
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
            Tidy.DesincrNbrPillow();
        }
        if (other.CompareTag("Pillow4"))
        {
            Tidy.DesincrNbrObject();
        }
        if (other.CompareTag("Pillow1"))
        {
            Tidy.DesincrNbrObject();

        }

    }
}

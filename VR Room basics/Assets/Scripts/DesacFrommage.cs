using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DesacFrommage : MonoBehaviour
{
    private Collider collideComponent;
    private XRGrabInteractable grabComponent;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Frommage"))
        {
            PizzaComplete.IncreaseStep();
            collideComponent = other.gameObject.GetComponent<BoxCollider>();
            grabComponent = other.gameObject.GetComponent<XRGrabInteractable>();
            collideComponent.enabled = false;
            grabComponent.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DesacVeg3 : MonoBehaviour
{
    private Collider collideComponent;
    private XRGrabInteractable grabComponent;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Veg3"))
        {
            PizzaComplete.IncreaseStep();
            collideComponent = other.gameObject.GetComponent<BoxCollider>();
            grabComponent = other.gameObject.GetComponent<XRGrabInteractable>();
            collideComponent.enabled = false;
            grabComponent.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DesacSauce : MonoBehaviour
{
    private Collider collideComponent;
    //private XRGrabInteractable grabComponent;
    //public GameObject pizza;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SauceTomate"))
        {
            //other.gameObject.transform.SetParent(pizza.transform);
            //PizzaComplete.IncreaseStep();
            collideComponent = other.gameObject.GetComponent<BoxCollider>();
            //grabComponent = other.gameObject.GetComponent<XRGrabInteractable>();
            collideComponent.enabled = false;
            //grabComponent.interactable = false;
        }
    }
}

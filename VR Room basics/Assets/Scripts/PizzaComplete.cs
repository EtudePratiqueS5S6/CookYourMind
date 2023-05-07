using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PizzaComplete : MonoBehaviour
{
    private static int currentStep = 0;
    public GameObject patePizza;
    private Collider collideComponent;
    private XRGrabInteractable grabComponent;

    // Update is called once per frame
    void Update()
    {
        if (currentStep == 5 && patePizza.transform.childCount == 5)
        {
            pizzaComp();
        }
    }

    private void pizzaComp()
    {
        collideComponent = patePizza.GetComponent<BoxCollider>();
        grabComponent = patePizza.GetComponent<XRGrabInteractable>();
        collideComponent.enabled = false;
        grabComponent.enabled = false;
    }

    public int getStep()
    {
        return currentStep;
    }

    public static void IncreaseStep()
    {
        currentStep++;
    }

}

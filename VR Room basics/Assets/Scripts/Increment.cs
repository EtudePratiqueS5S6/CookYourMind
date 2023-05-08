using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increment : MonoBehaviour
{
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PatePizza") && PizzaComplete.getStep()==0)
        {
            if (PizzaComplete.getStep() == 0)
            {
                PizzaComplete.increaseStep();

            }
            PizzaComplete.increaseIngr();
        }
        else if (other.CompareTag("TomatoSauce"))
        {
            if (PizzaComplete.getStep() == 1)
            {
                PizzaComplete.increaseStep();

            }
            PizzaComplete.increaseIngr();
        }
        else if (other.CompareTag("Veg1"))
        {
            if (PizzaComplete.getStep() == 2)
            {
                PizzaComplete.increaseStep();

            }
            PizzaComplete.increaseIngr();
        }
        else if (other.CompareTag("Veg2"))
        {
            if (PizzaComplete.getStep() == 3)
            {
                PizzaComplete.increaseStep();

            }
            PizzaComplete.increaseIngr();
        }
        else if (other.CompareTag("Veg3"))
        {
            if (PizzaComplete.getStep() == 4)
            {
                PizzaComplete.increaseStep();

            }
            PizzaComplete.increaseIngr();
        }
        else if (other.CompareTag("Mozza"))
        {
            if (PizzaComplete.getStep() == 5)
            {
                PizzaComplete.increaseStep();

            }
            PizzaComplete.increaseIngr();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PatePizza"))
        {
            if (PizzaComplete.getStep() == 1)
            {
                PizzaComplete.decreaseStep();

            }
            PizzaComplete.decreaseNbIngr();
        }
        else if (other.CompareTag("TomatoSauce"))
        {
            if (PizzaComplete.getStep() == 2)
            {
                PizzaComplete.decreaseStep();

            }
            PizzaComplete.decreaseNbIngr();
        }
        else if (other.CompareTag("Veg1"))
        {
            if (PizzaComplete.getStep() == 3)
            {
                PizzaComplete.decreaseStep();

            }
            PizzaComplete.decreaseNbIngr();
        }
        else if (other.CompareTag("Veg2"))
        {
            if (PizzaComplete.getStep() == 4)
            {
                PizzaComplete.decreaseStep();

            }
            PizzaComplete.decreaseNbIngr();
        }
        else if (other.CompareTag("Veg3"))
        {
            if (PizzaComplete.getStep() == 5)
            {
                PizzaComplete.decreaseStep();

            }
            PizzaComplete.decreaseNbIngr();
        }
        else if (other.CompareTag("Mozza"))
        {
            if (PizzaComplete.getStep() == 6)
            {
                PizzaComplete.decreaseStep();

            }
            PizzaComplete.decreaseNbIngr();
        }
    }
}

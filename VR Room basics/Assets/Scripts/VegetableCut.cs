using UnityEngine;

public class VegetableCut : MonoBehaviour
{
    public GameObject choppedVegetable;
    
    void OnTriggerEnter(Collider other)
    {
        // rempace l'objet par choppedVegetable si un objet avec le tag package entre dans le collider
        if (other.gameObject.CompareTag("KnifeKitchen"))
        {
            gameObject.SetActive(false);
            Vector3 pos = gameObject.transform.position;
            choppedVegetable.transform.position = pos;
            choppedVegetable.SetActive(true);
        }
    }
}

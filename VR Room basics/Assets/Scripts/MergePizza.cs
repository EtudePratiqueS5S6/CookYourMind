using System.IO;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MergePizza : MonoBehaviour
{
    public GameObject patePizza;
    public GameObject sauceTomate;
    public GameObject veg1;
    public GameObject veg2;
    public GameObject veg3;
    public GameObject frommage;
    private XRGrabInteractable grabInteractable;
    private Rigidbody rigidbody;
    private StreamWriter sw;
    private bool isHeaderWritten = false;
    private string filePath = Enregistrement_nom_prenom.csvFilePath;
    
    private void Start()
    {
        // Ouvre le fichier CSV en mode append pour ajouter des données à la fin
        sw = new StreamWriter(filePath, true);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == sauceTomate)
        {
            if (patePizza.transform.childCount == 0)
            {
                other.gameObject.transform.SetParent(patePizza.transform);
                other.gameObject.transform.localPosition = Vector3.zero;
            }
        }
        else if (other.gameObject == veg1)
        {
            if (patePizza.transform.childCount == 1 && patePizza.transform.GetChild(0).gameObject == sauceTomate)
            {
                other.gameObject.transform.SetParent(patePizza.transform);
                other.gameObject.transform.localPosition = Vector3.zero;
            }
        }
        else if (other.gameObject == veg2)
        {
            if (patePizza.transform.childCount == 2 && patePizza.transform.GetChild(0).gameObject == sauceTomate && patePizza.transform.GetChild(1).gameObject == veg1)
            {
                other.gameObject.transform.SetParent(patePizza.transform);
                other.gameObject.transform.localPosition = Vector3.zero;

                // Fusion des ingrédients
                CombineIngredients();
            }
        }
        else if (other.gameObject == veg3)
        {
            if (patePizza.transform.childCount == 2 && patePizza.transform.GetChild(0).gameObject == sauceTomate && patePizza.transform.GetChild(1).gameObject == veg1 && patePizza.transform.GetChild(2).gameObject == veg2)
            {
                other.gameObject.transform.SetParent(patePizza.transform);
                other.gameObject.transform.localPosition = Vector3.zero;

                // Fusion des ingrédients
                CombineIngredients();
            }
        }
        else if (other.gameObject == frommage)
        {
            if (patePizza.transform.childCount == 2 && patePizza.transform.GetChild(0).gameObject == sauceTomate && patePizza.transform.GetChild(1).gameObject == veg1 && patePizza.transform.GetChild(2).gameObject == veg2 && patePizza.transform.GetChild(3).gameObject == veg3)
            {
                other.gameObject.transform.SetParent(patePizza.transform);
                other.gameObject.transform.localPosition = Vector3.zero;

                // Fusion des ingrédients
                CombineIngredients();
                exportSucces();
            }
        }
    }

    private void CombineIngredients()
    {
        // Création d'un nouveau GameObject
        GameObject pizzaComplete = new GameObject("PizzaComplete");

        // Ajout d'un rigidbody pour pouvoir saisir la pizza
        pizzaComplete.AddComponent<Rigidbody>();
        
        rigidbody = pizzaComplete.GetComponent<Rigidbody>();

        pizzaComplete.AddComponent<XRGrabInteractable>();
        
        grabInteractable = pizzaComplete.GetComponent<XRGrabInteractable>();

        rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        grabInteractable.movementType = XRGrabInteractable.MovementType.Kinematic;
        
        grabInteractable.movementType = XRGrabInteractable.MovementType.Kinematic;

        grabInteractable.smoothPosition = true;

        grabInteractable.smoothRotation = true;

        // Positionnement de la pizza au même endroit que l'objet Pizza
        pizzaComplete.transform.position = transform.position;

        // Ajout de la pâte à pizza à la pizza complète
        patePizza.transform.SetParent(pizzaComplete.transform);

        // Ajout des légumes à la pizza complète
        foreach (Transform child in patePizza.transform)
        {
            child.SetParent(pizzaComplete.transform);
        }

        // Suppression de l'objet Pizza
        Destroy(gameObject);
    }
    
    private void exportSucces()
    {
        // Écrit le titre de la nouvelle colonne si ce n'est pas déjà fait
        if (!isHeaderWritten)
        {
            sw.Write(", Pizza faite");
            isHeaderWritten = true;
        }

        // Écrit la valeur de la nouvelle colonne pour la ligne suivante
        sw.Write(", Succes");

        // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
        sw.Flush();
    }
    
    private void OnDestroy()
    {
        if (!isHeaderWritten)
        {
            sw.Write(", Pizza faite");
            isHeaderWritten = true;
            // Écrit la valeur de la nouvelle colonne pour la ligne suivante
            sw.Write(", Echec");

            // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
            sw.Flush();
        }
        // Ferme le StreamWriter lorsque le jeu est quitté
        sw.Close();
    }
}

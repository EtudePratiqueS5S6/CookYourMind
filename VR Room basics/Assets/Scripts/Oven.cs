using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public GameObject pate;
    public GameObject sauce;
    public GameObject veg1;
    public GameObject veg2;
    public GameObject veg3;
    public GameObject mozza;
    public GameObject platCuit;
    public GameObject platCrame;
    public AudioSource minuteur;
    public GameObject fourLight;

    private bool isCooking = false;
    private bool cuisson = true;
    private bool brule = true;
    private float cookingTimer = 0f;
    private float cookingTime = 60f; // 15 secondes
    private Vector3 pos;


    public static StreamWriter sw;
    private bool isHeaderWritten = false;
    
    private string filePath = SaveNames.getFilePath();
    private string nom;
    private string prenom;
    private string ID_partie;

    private void Start()
    {
        //au lancement de la scene, on enregistre la position de la plaque
        pos = gameObject.transform.position;
        Debug.Log(string.Format("Initialisation de la pos de la pizza ok"));
        // Ouvre le fichier CSV en mode append pour ajouter des données à la fin
        sw = new StreamWriter(filePath);
        nom = SaveNames.getNom();
        prenom = SaveNames.getPrenom();
        ID_partie = SaveNames.getID();
    }
    private void Update()
    {
        if (isCooking)
        {
            //si la pizza est en train de cuire on continue d'incrementer le timer
            cookingTimer += Time.deltaTime;

            if (cookingTimer >= cookingTime + 30f)
            {
                //si le temps de cuisson est largement depassé
                // Plat cramé
                Debug.Log(string.Format("Plat cramé"));
                cuitToCrame();
                // Réinitialiser le minuteur
                cookingTimer = 0f;

                exportEchec();
            }
            else if (cookingTimer >= cookingTime)
            {
                //si le temps de cuisson est atteint
                // Plat cuit
                cruToCuit();
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plaque") && !isCooking && cuisson )
        {
            Debug.Log(string.Format("Lancement de la cuisson"));
            // Plat cru placé sur la socket
            isCooking = true;
            
            // Allumer la lumière du four
            fourLight.SetActive(true);

            // Lancer le minuteur
            cookingTimer = 0f;

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Plaque") &&  !cuisson)
        {
            // Plat cru retiré de la socket
            isCooking = false;

            // Éteindre la lumière du four
            fourLight.SetActive(false);

            // Réinitialiser le minuteur
            cookingTimer = 0f;

            exportSucces();
        }
    }

    

    private void cruToCuit()
    {
        //permet de remplacer la pizza cru par la pizza cuite qu'une seule fois malgré le update()
        if (cuisson)
        {
            
            minuteur.Play();
            cuisson = false;

            Debug.Log(string.Format("Remplacement pizza cru"));
            mozza.SetActive(false);  
            veg1.SetActive(false);  
            veg2.SetActive(false);  
            veg3.SetActive(false);  
            pate.SetActive(false);  
            sauce.SetActive(false);  
            platCuit.transform.position = pos;
            platCuit.SetActive(true);
        }
    }

    private void cuitToCrame()
    {
        //permet de remplacer la pizza cuite par la pizza cramée qu'une seule fois malgré le update()
        if (brule)
        {
            brule = false;
            isCooking = false;
            // Éteindre la lumière du four
            fourLight.SetActive(false);

            Debug.Log(string.Format("Remplacement pizza cuite"));
            platCuit.SetActive(false);
            platCrame.transform.position = pos;
            platCrame.SetActive(true);
            
            
        }
    }

    private void exportSucces()
    {
        // enregistrement du succes si la pizza est cuite et sortie du four à temps
        if (!isHeaderWritten)
        {
            sw.Write("{0}\t{1}\t{2}\tPizza cuite\tSucces\n", ID_partie, nom, prenom);
            isHeaderWritten = true;
            sw.Flush();
        }
    }

    private void exportEchec()
    {
        // enregistr ment de l'echec si la pizza crame
        if (!isHeaderWritten)
        {
            sw.Write("{0}\t{1}\t{2}\tPizza cuite\tEchec : Pizza brulée\n", ID_partie, nom, prenom);
            isHeaderWritten = true;
            sw.Flush();
        }
    }
    
    private void OnDestroy()
    {
        if (!isHeaderWritten)
        {
            // enregestrement de l'echec si une etape autre n'a pas été respectée (expl : pizza retiree trop tot)
            sw.Write("{0}\t{1}\t{2}\tPizza cuite\tEchec\n", ID_partie, nom, prenom);
            isHeaderWritten = true;

            // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
            sw.Flush();
        }
        
    }
}

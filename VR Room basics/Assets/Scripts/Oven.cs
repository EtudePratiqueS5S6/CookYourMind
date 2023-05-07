using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public GameObject platCru;
    public GameObject platCuit;
    public GameObject platCrame;
    public AudioSource minuteur;
    public GameObject fourLight;

    private bool isCooking = false;
    private bool minut = true;
    private bool cuisson = true;
    private bool brule = true;
    private float cookingTimer = 0f;
    private float cookingTime = 30f; // 4 minutes en secondes

    private StreamWriter sw;
    private bool isHeaderWritten = false;
    private string filePath = Enregistrement_nom_prenom.getFilePath();
    private Vector3 pos;

    private void Start()
    {
        // Ouvre le fichier CSV en mode append pour ajouter des données à la fin
        sw = new StreamWriter(filePath, true);
        pos = other.gameObject.transform.position;
    }
    private void Update()
    {
        if (isCooking)
        {
            cookingTimer += Time.deltaTime;

            if (cookingTimer >= cookingTime+20f)
            {
                // Plat cramé
                Debug.Log(string.Format("Plat cramé"));
                platCuit.SetActive(false);
                Vector3 pos = platCuit.transform.position;
                platCrame.transform.position = pos;
                platCrame.SetActive(true);
                isCooking = false;
                // Éteindre la lumière du four
                fourLight.SetActive(false);

                // Réinitialiser le minuteur
                cookingTimer = 0f;

                exportEchec();
            }
            else if (cookingTimer >= cookingTime)
            {
                // Plat cuit
                Debug.Log(string.Format("Plat cuit"));
                minuteur.Play();
                cruToCuit();
                minut = false;
                cuisson = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plaque") && !isCooking)
        {
            Debug.Log(string.Format("lancement de la cuisson"));
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
        if (other.gameObject.CompareTag("PlatCuit"))
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

    private void playAudio()
    {
        if (minut)
        {
            minuteur.Play();
        }
    }

    private void cruToCuit()
    {
        if (cuisson)
        {
            platCru.SetActive(false);
            platCuit.transform.position = pos;
            platCuit.SetActive(true);
        }
    }

    private void cuitToCrame()
    {
        if (brule)
        {
            platCru.SetActive(false);
            platCuit.transform.position = pos;
            platCuit.SetActive(true);
        }
    }

    private void exportSucces()
    {
        // Écrit le titre de la nouvelle colonne si ce n'est pas déjà fait
        if (!isHeaderWritten)
        {
            sw.Write("Pizza cuite\tSucces");
            isHeaderWritten = true;
            sw.Flush();
        }

        // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
        
        sw.Close();
    }

    private void exportEchec()
    {
        // Écrit le titre de la nouvelle colonne si ce n'est pas déjà fait
        if (!isHeaderWritten)
        {
            sw.Write("Pizza cuite\tEchec : pizza cramée");
            isHeaderWritten = true;
            sw.Flush();
        }

        // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
        
        sw.Close();
    }
    
    private void OnDestroy()
    {
        if (!isHeaderWritten)
        {
            sw.Write("Pizza cuite\tEchec");
            isHeaderWritten = true;

            // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
            sw.Flush();
        }
        // Ferme le StreamWriter lorsque le jeu est quitté
        sw.Close();
    }
}

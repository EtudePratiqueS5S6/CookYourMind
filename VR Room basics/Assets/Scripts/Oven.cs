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
    public Light fourLight;

    private bool isCooking = false;
    private bool minut = true;
    private float cookingTimer = 0f;
    private float cookingTime = 240f; // 4 minutes en secondes

    private StreamWriter sw;
    private bool isHeaderWritten = false;
    private string filePath = Enregistrement_nom_prenom.csvFilePath;

    private void Start()
    {
        // Ouvre le fichier CSV en mode append pour ajouter des données à la fin
        sw = new StreamWriter(filePath, true);
    }
    private void Update()
    {
        if (isCooking)
        {
            cookingTimer += Time.deltaTime;

            if (cookingTimer >= cookingTime)
            {
                // Plat cramé
                platCuit.SetActive(false);
                platCrame.SetActive(true);
                isCooking = false;
                // Éteindre la lumière du four
                fourLight.enabled = false;

                // Réinitialiser le minuteur
                cookingTimer = 0f;

                exportEchec();
            }
            else if (cookingTimer >= cookingTime - 60f)
            {
                // Plat cuit
                playAudio();
                platCru.SetActive(false);
                platCuit.SetActive(true);
                minut = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlatCru") && !isCooking)
        {
            // Plat cru placé sur la socket
            isCooking = true;

            // Allumer la lumière du four
            fourLight.enabled = true;

            // Lancer le minuteur
            cookingTimer = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlatCuit"))
        {
            // Plat cru retiré de la socket
            isCooking = false;

            // Éteindre la lumière du four
            fourLight.enabled = false;

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

    private void exportSucces()
    {
        // Écrit le titre de la nouvelle colonne si ce n'est pas déjà fait
        if (!isHeaderWritten)
        {
            sw.Write(", Pizza cuite");
            isHeaderWritten = true;
        }

        // Écrit la valeur de la nouvelle colonne pour la ligne suivante
        sw.Write(", Succes");

        // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
        sw.Flush();
    }

    private void exportEchec()
    {
        // Écrit le titre de la nouvelle colonne si ce n'est pas déjà fait
        if (!isHeaderWritten)
        {
            sw.Write(", Pizza cuite");
            isHeaderWritten = true;
        }

        // Écrit la valeur de la nouvelle colonne pour la ligne suivante
        sw.Write(", Echec : pizza cramée");

        // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
        sw.Flush();
    }
    
    private void OnDestroy()
    {
        if (!isHeaderWritten)
        {
            sw.Write(", Pizza cuite");
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

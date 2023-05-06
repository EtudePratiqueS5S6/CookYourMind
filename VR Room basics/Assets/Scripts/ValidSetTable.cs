using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ValidSetTable : MonoBehaviour
{
    private int assiettesCount = 0;
    private int couvertsCount = 0;
    private int verresCount = 0;
    private bool tableSet = false;
    private int nbAssiettes = 4;
    private int nbVerres = 4;
    private int nbCouverts = 8;
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
        if (other.CompareTag("Assiette"))
        {
            assiettesCount++;
            CheckTableSet();
        }
        else if (other.CompareTag("Couvert"))
        {
            couvertsCount++;
            CheckTableSet();
        }
        else if (other.CompareTag("Verres"))
        {
            verresCount++;
            CheckTableSet();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Assiette"))
        {
            assiettesCount--;
            CheckTableSet();
        }
        else if (other.CompareTag("Couvert"))
        {
            couvertsCount--;
            CheckTableSet();
        }
        else if (other.CompareTag("Verres"))
        {
            verresCount--;
            CheckTableSet();
        }
    }

    private void CheckTableSet()
    {
        if (assiettesCount >= nbAssiettes && couvertsCount >= nbCouverts && verresCount >= nbVerres)
        {
            if (!tableSet)
            {
                tableSet = true;
                exportSucces();
            }
        }
        else
        {
            tableSet = false;
        }
    }
    
    private void exportSucces()
    {
        // Écrit le titre de la nouvelle colonne si ce n'est pas déjà fait
        if (!isHeaderWritten)
        {
            sw.Write(", Mettre la table");
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
            sw.Write(", Mettre la table");
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

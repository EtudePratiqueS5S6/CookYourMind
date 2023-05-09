using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ValidSetTable : MonoBehaviour
{
    private int nbCutlery;
    private static int nbCutleryPlaced = 0;
    private StreamWriter sw;
    private bool isHeaderWritten = false;
    private string nom;
    private string prenom ;
    private string ID_partie ;

    void Start()
    {
        //on recupère le StreamWritter deja ouvert dans le script Oven
        sw = Oven.sw ;
        nom = SaveNames.getNom();
        prenom = SaveNames.getPrenom();
        ID_partie = SaveNames.getID();
        nbCutlery = 16;
    }

    void Update()
    {
        if (nbCutleryPlaced >= nbCutlery)
        {
            exportSucces();
            Debug.Log(string.Format("Nombre couverts ok"));
        }
    }

    private void exportSucces()
    {
        // enregistrement du succes si la pizza est complete et dans le bon ordre
        if (!isHeaderWritten)
        {
            sw.Write("{0}\t{1}\t{2}\tTable mise\tSucces", ID_partie, nom, prenom);
            isHeaderWritten = true;
            sw.Flush();
            Debug.Log(string.Format("Succes table mise"));
        }
    }
    
    private void OnDestroy()
    {
        if (!isHeaderWritten)
        {
            //si on a jamais ecrit dans le csv alors le succes n'a pas ete enregistré donc c'est un echec
            sw.WriteLine("{0}\t{1}\t{2}\tTable mise\tEchec", ID_partie, nom, prenom);
            isHeaderWritten = true;
            Debug.Log(string.Format("Echec table mise"));
            // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
            sw.Flush();
        }
     
    }

    public static void IncreaseCutleryPlaced()
    {
        nbCutleryPlaced++;
        Debug.Log(string.Format("ajout couvert"));
    }
}

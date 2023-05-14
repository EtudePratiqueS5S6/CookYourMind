using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PizzaComplete : MonoBehaviour
{
    private static int currentStep = 0;
    private static int nbIngr = 0;
    private Collider collideComponent;
    private XRGrabInteractable grabComponent;
    public static bool fini = false;
    
    private StreamWriter sw;
    private bool isHeaderWritten = false;
    
    private string nom;
    private string prenom ;
    private string ID_partie ;

    void Start()
    {
        //on recupère le StreamWritter deja ouvert dans le script Oven
        sw = Oven.sw;
        nom = SaveNames.getNom();
        prenom = SaveNames.getPrenom();
        ID_partie = SaveNames.getID();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (currentStep == 6 && nbIngr == 6)
        {
            exportSucces();
        }

        if (nbIngr >= 6 && currentStep < 6)
        {
            exportFailure();
        }
    }
    
    

    public static int getStep()
    {
        return currentStep;
    }
    public static int getNbIngr()
    {
        return nbIngr;
    }

    public static void increaseStep()
    {
        currentStep++;
        Debug.Log(string.Format("incr etape"));
    }
    public static void increaseIngr()
    {
        nbIngr++;
        Debug.Log(string.Format("incr ingredient"));
    }

    public static void decreaseStep()
    {
        currentStep--;
        Debug.Log(string.Format("decr step"));
    }
    public static void decreaseNbIngr()
    {
        nbIngr--;
        Debug.Log(string.Format("decr ingredient"));

    }

    private void exportSucces()
    {
        // enregistrement du succes si la pizza est complete et dans le bon ordre
        if (!isHeaderWritten)
        {
            sw.Write("{0}\t{1}\t{2}\tPizza complete\tSucces\n", ID_partie, nom, prenom);
            isHeaderWritten = true;
            sw.Flush();
            Debug.Log(string.Format("Succes pizza complete"));
        }
    }
    private void exportFailure()
    {
        // enregistrement du succes si la pizza est complete et dans le bon ordre
        if (!isHeaderWritten)
        {
            sw.Write("{0}\t{1}\t{2}\tPizza complete\tEchec : Mauvais ordre\n", ID_partie, nom, prenom);
            isHeaderWritten = true;
            sw.Flush();
            Debug.Log(string.Format("Echec pizza : Mauvais ordre"));
        }
    }
    
    private void OnDestroy()
    {
        if (!isHeaderWritten)
        {
            //si on a jamais ecrit dans le csv alors le succes n'a pas ete enregistré donc c'est un echec
            sw.Write("{0}\t{1}\t{2}\tPizza complete\tEchec\n", ID_partie, nom, prenom);
            isHeaderWritten = true;
            Debug.Log(string.Format("Echec pizza complete"));
            // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
            sw.Flush();
        }
     
    }

}

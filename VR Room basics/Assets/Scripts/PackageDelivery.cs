using System.IO;
using UnityEngine;


public class PackageDelivery : MonoBehaviour
{
    private int time;
    private int event1;
    public GameObject package;
    public GameObject canvaDelivery;
    public AudioSource sonnette;
    private StreamWriter sw;
    private bool isHeaderWritten = false;
    
    private string nom;
    private string prenom ;
    private string ID_partie ;

    void Awake()
    {
        //temps d'attentre avant la livraison initialisé avant le lancement de la scène
        time = (int)Time.time;
        event1 = 60;
    }

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
        time = (int)Time.time;
        if (time == event1)
        {
            //quand on arrive à l'heure de la livraison on declanche la livraison
            DisplayPackage();
        }
    }

    private void DisplayPackage()
    {
        //fait apparaitre le paquet et le canva
        canvaDelivery.SetActive(true);
        package.SetActive(true);
        sonnette.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("package"))
        {
            //si un objet avec le tag package entre dans le collider
            if (!isHeaderWritten)
            {
                //si on a pas deja ecrit dans le csv, on enregistre le succes
                sw.Write("{0}\t{1}\t{2}\tColis\tSucces\n", ID_partie, nom, prenom);
                isHeaderWritten = true;
                sw.Flush();
                Debug.Log(string.Format("Succes package delivery"));
            }
        }
    }
    
    private void OnDestroy()
    {
        if (!isHeaderWritten)
        {
            //si on a jamais ecrit dans le csv alors le succes n'a pas ete enregistré donc c'est un echec
            sw.Write("{0}\t{1}\t{2}\tColis\tEchec\n", ID_partie, nom, prenom);
            isHeaderWritten = true;
            Debug.Log(string.Format("Echec package delivery"));

            // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
            sw.Flush();
        }
     
    }
}

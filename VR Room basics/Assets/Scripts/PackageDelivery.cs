using System.IO;
using UnityEngine;


public class PackageDelivery : MonoBehaviour
{
    private int time;
    private int event1;
    public GameObject package;
    public GameObject canva;
    public AudioSource sonnette;
    private StreamWriter sw;
    private bool isHeaderWritten = false;
    private string filePath = Enregistrement_nom_prenom.csvFilePath;
    void Awake()
    {
        time = (int)Time.time;
        event1 = 120;
    }
    
    private void Start()
    {
        // Ouvre le fichier CSV en mode append pour ajouter des données à la fin
        sw = new StreamWriter(filePath, true);
    }

    // Update is called once per frame
    void Update()
    {
        time = (int)Time.time;
        if (time == event1)
        {
            DisplayPackage();
        }
    }

    private void DisplayPackage()
    {
        canva.SetActive(true);
        package.SetActive(true);
        sonnette.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("package"))
        {
            if (!isHeaderWritten)
            {
                sw.Write(", Colis");
                isHeaderWritten = true;
            }

            // Écrit la valeur de la nouvelle colonne pour la ligne suivante
            sw.Write(", Succes");

            // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
            sw.Flush();
        }
    }
    
    private void OnDestroy()
    {
        if (!isHeaderWritten)
        {
            sw.Write(", Colis");
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

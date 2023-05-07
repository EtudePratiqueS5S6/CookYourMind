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

    void Awake()
    {
        time = (int)Time.time;
        event1 = 20;
    }

    void Start()
    {
        sw = new StreamWriter(Enregistrement_nom_prenom.csvFilePath, true);
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
        canvaDelivery.SetActive(true);
        package.SetActive(true);
        sonnette.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("package"))
        {
            if (!isHeaderWritten)
            {
                sw.WriteLine("Colis\tSucces");
                isHeaderWritten = true;
            }

            // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
            sw.Flush();
        }
    }
    
    private void OnDestroy()
    {
        if (!isHeaderWritten)
        {
            sw.WriteLine("Colis\tEchec");
            isHeaderWritten = true;

            // Flush les données pour s'assurer qu'elles sont bien écrites dans le fichier
            sw.Flush();
        }
        
        // Ferme le StreamWriter lorsque le jeu est quitté
        sw.Close();
    }
}

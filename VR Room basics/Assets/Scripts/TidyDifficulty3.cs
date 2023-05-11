using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TidyDifficulty3 : MonoBehaviour
{
    public GameObject tidy1;
    public GameObject tidy2;
    public GameObject tidy3;
    public GameObject tidy4;
    public GameObject tidy5;
    public GameObject tidy6;
    public GameObject tidy7;
    public GameObject tidy8;
    public GameObject tidy9;
    public GameObject untidy1;
    public GameObject untidy2;
    public GameObject untidy3;
    public GameObject untidy4;
    public GameObject untidy5;
    public GameObject untidy6;
    public GameObject untidy7;
    public GameObject untidy8;
    public GameObject untidy9;
    private static int nbrTidyObjects;
    private static int nbrPillow;

    private int time;
    private int event1;
    public AudioSource kids;

    private StreamWriter sw;
    private bool isHeaderWritten = false;
    private string nom;
    private string prenom;
    private string ID_partie;

    void Awake()
    {
        //temps d'attentre avant le dérangement
        time = (int)Time.time;
        event1 = 120;
    }

    void Start()
    {
        //on recupère le StreamWritter deja ouvert dans le script Oven
        sw = Oven.sw;
        nom = SaveNames.getNom();
        prenom = SaveNames.getPrenom();
        ID_partie = SaveNames.getID();
        nbrTidyObjects = 0;
        nbrPillow = 0;
    }



    void Update()
    {
        if (time == event1)
        {
            EnableObjectsAfterDuration();
        }
        if (nbrTidyObjects == 9 && nbrPillow != 4)
        {
            ExportHalfSucces();
        }
        if (nbrTidyObjects == 9 && nbrPillow == 4)
        {
            ExportFullSucces();
        }

    }

    void EnableObjectsAfterDuration()
    {
        //Désactiver tous les objets rangés
        tidy1.SetActive(false);
        tidy2.SetActive(false);
        tidy3.SetActive(false);
        tidy4.SetActive(false);
        tidy5.SetActive(false);
        tidy6.SetActive(false);
        tidy7.SetActive(false);
        tidy8.SetActive(false);
        tidy9.SetActive(false);

        kids.Play();
        // Activer tous les objets de la liste
        untidy1.SetActive(true);
        untidy2.SetActive(true);
        untidy3.SetActive(true);
        untidy4.SetActive(true);
        untidy5.SetActive(true);
        untidy6.SetActive(true);
        untidy7.SetActive(true);
        untidy8.SetActive(true);
        untidy9.SetActive(true);
    }

    public static void IncrNbrObject()
    {
        nbrTidyObjects++;
    }
    public static void DesincrNbrObject()
    {
        nbrTidyObjects--;
    }
    public static void IncrNbrPillow()
    {
        nbrPillow++;
    }
    public static void DesincrNbrPillow()
    {
        nbrPillow--;
    }

    private void ExportHalfSucces()
    {
        // enregistrement du succes si la piece est rangé mais les oreillers pas dans le bon ordre
        if (!isHeaderWritten)
        {
            sw.Write("{0}\t{1}\t{2}\tPiece rangée\tSucces\n", ID_partie, nom, prenom);
            sw.Write("{0}\t{1}\t{2}\tOrdre oreillers\tEchec\n", ID_partie, nom, prenom);

            isHeaderWritten = true;
            sw.Flush();
            Debug.Log(string.Format("Piece rangée mais oreillers dans le mauvais ordre"));
        }
    }
    private void ExportFullSucces()
    {
        // enregistrement du succes si la piece est rangé avec les oreillers dans le bon ordre
        if (!isHeaderWritten)
        {
            sw.Write("{0}\t{1}\t{2}\tPiece rangée\tSucces\n", ID_partie, nom, prenom);
            sw.Write("{0}\t{1}\t{2}\tOrdre oreillers\tSucces\n", ID_partie, nom, prenom);

            isHeaderWritten = true;
            sw.Flush();
            Debug.Log(string.Format("Piece rangée et oreillers dans le bon ordre"));
        }
    }
}

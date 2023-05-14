using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.IO;

public class SaveNames : MonoBehaviour
{
    public TMP_InputField firstNameField;
    public TMP_InputField lastNameField;
    public Button bouton1;
    public Button bouton2;
    public Button bouton3;
    public static string firstName;
    public static string lastName;
    public static string csvFilePath;
    public static string ID_partie;

    //getter pour les donnees dont on a besoin pour le fichier csv
    public static string getFilePath()
    {
        return csvFilePath;
    }
    public static string getID()
    {
        return ID_partie;
    }
    public static string getNom()
    {
        return lastName;
    }
    public static string getPrenom()
    {
        return firstName;
    }

    void Start()
    {
        bouton1.onClick.AddListener(() => OnClickBouton(1));
        bouton2.onClick.AddListener(() => OnClickBouton(2));
        bouton3.onClick.AddListener(() => OnClickBouton(3));
    }

    private void OnClickBouton(int boutonID)
    {
        switch (boutonID)
        {
            case 1:
                ID_partie = string.Format("{0:yyyy-MM-dd_HH-mm-ss}_diff1", DateTime.Now);
                break;
            case 2:
                ID_partie = string.Format("{0:yyyy-MM-dd_HH-mm-ss}_diff2", DateTime.Now);
                break;
            case 3:
                ID_partie = string.Format("{0:yyyy-MM-dd_HH-mm-ss}_diff3", DateTime.Now);
                break;
            default:
                ID_partie = string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
                break;
        }
    }

        public void SaveToCSV()
    {
        string fileName = string.Format("Données_patients.csv");
        csvFilePath = Application.dataPath + "/" + fileName;
        // Cr?ation du fichier CSV
        firstName = firstNameField.text;
        lastName = lastNameField.text;
        Debug.Log(string.Format("Nom {0}, Prenom {1}", lastName, firstName));

    }
}

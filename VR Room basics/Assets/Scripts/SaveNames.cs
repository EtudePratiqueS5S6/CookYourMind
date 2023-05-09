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
    public static string firstName;
    public static string lastName;
    public static string csvFilePath;
    public static string ID_partie;
    private StreamWriter writer;

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
        // G?n?re un nom de fichier unique bas? sur la date et l'heure actuelles
        string date = string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
        string fileName = string.Format("UserData_{0}.csv", date);
        csvFilePath = Application.dataPath + "/" + fileName;
        ID_partie = date;
        writer = new StreamWriter(csvFilePath, true);

    }


    public void SaveToCSV()
    { 
            // Cr?ation du fichier CSV
            firstName = firstNameField.text;
            lastName = lastNameField.text;
            writer.Write("{0}\t{1}\t{2}", ID_partie, lastName, firstName);
            writer.Close();
            Debug.Log(string.Format("Fichier CSV cree"));
            Debug.Log(string.Format("Nom"));
        
    }
}

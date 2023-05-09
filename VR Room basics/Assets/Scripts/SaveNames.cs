using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using System.IO;

public class SaveNames : MonoBehaviour
{
    public static TMP_InputField firstNameField;
    public static TMP_InputField lastNameField;
    private static string firstName;
    private static string lastName;
    public static string csvFilePath;
    public static string ID_partie;
    public static StreamWriter writer;

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

    private void Start()
    {
        // G?n?re un nom de fichier unique bas? sur la date et l'heure actuelles
        string date = string.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
        string fileName = string.Format("UserData_{0}.csv", date);
        csvFilePath = Application.dataPath + "/" + fileName;
        ID_partie = date;

    }


    public void SaveToCSV()
    {

        try
        {
            // Cr?ation du fichier CSV
            using (writer = new StreamWriter(csvFilePath))
            {
                writer.WriteLine("{0}\t{1}\t{2}", ID_partie, lastNameField.text, firstNameField.text);
                writer.Flush();
                writer.Close();
            }
            firstName = firstNameField.text;
            lastName = lastNameField.text;
            Debug.Log(string.Format("Fichier CSV cr?? ? l'emplacement {0}", csvFilePath));
            Debug.Log(string.Format("{0}, {1}", firstName, lastName));
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}

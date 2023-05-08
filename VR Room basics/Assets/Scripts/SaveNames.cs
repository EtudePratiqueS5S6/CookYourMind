using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveNames : MonoBehaviour
{
    public static TMP_InputField firstNameField;
    public static TMP_InputField lastNameField;
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
        return lastNameField.text;
    }
    public static string getPrenom()
    {
        return firstNameField.text;
    }

    private void Start()
    {
        // G�n�re un nom de fichier unique bas� sur la date et l'heure actuelles
        string date = string.Format("{0:yyyy-MM-dd_HH-mm-ss", DateTime.Now);
        string fileName = string.Format("UserData_"+date+".csv", DateTime.Now);
        csvFilePath = Application.dataPath + "/" + fileName;
        ID_partie = date;

    }


    public void SaveToCSV()
    {

        try
        {
            // Cr�ation du fichier CSV
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                writer.WriteLine("{0}\t{1}", lastNameField.text, firstNameField.text);
                writer.Flush();
                writer.Close();
            }

            Debug.Log(string.Format("Fichier CSV cr�� � l'emplacement {0}", csvFilePath));
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

}


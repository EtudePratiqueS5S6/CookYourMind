using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enregistrement_nom_prenom : MonoBehaviour
{
    public TMP_InputField firstNameField;
    public TMP_InputField lastNameField;
    public static string csvFilePath;

    private void Start()
    {
        // Génère un nom de fichier unique basé sur la date et l'heure actuelles
        string fileName = string.Format("UserData_{0:yyyy-MM-dd_HH-mm-ss}.csv", DateTime.Now);
        csvFilePath = Application.dataPath + "/" + fileName;

    }


    public void SaveToCSV()
    {

        try
        {
            // Création du fichier CSV
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                writer.WriteLine("Nom,Prenom");
                writer.WriteLine("{0},{1}", lastNameField.text, firstNameField.text);
                writer.Close();
            }

            Debug.Log(string.Format("Fichier CSV créé à l'emplacement {0}", csvFilePath));
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}


using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FileName : MonoBehaviour
{
    public InputField inputField;
    public string fileName;
    public void Export()
    {
        
        fileName = inputField.text + "_VR";
        string path = "/C:" + fileName;
        File.Create(path).Dispose();

        using (StreamWriter writer = new StreamWriter(path, false))
        {
            writer.Write(inputField.text);
        }

        Debug.Log("File exported to: " + path);
    }
}

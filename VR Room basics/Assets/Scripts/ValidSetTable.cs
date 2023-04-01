using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ValidSetTable : MonoBehaviour
{
    public FileName filename;
    private GameObject[] socketList;
    private int valid;
    // Start is called before the first frame update
    void Start()
    {
        socketList = GameObject.FindGameObjectsWithTag("tableSocket");
        valid = 0;
    }

    // Update is called once per frame
    void Update()
    {
        valid = 0;
        for (int i = 0; i<socketList.Length; i++)
        {
            //SocketBool socketBool = socketList[i].GetComponent<SocketBool>();
            XRSocketInteractor interactor = socketList[i].GetComponent<XRSocketInteractor>();
            if (interactor.isHoverActive)
            {
                valid++;
            } 
        }

        if (valid == socketList.Length)
        {
            string path = Application.persistentDataPath + "/" + filename.fileName;
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.Write("Le patient a bien mis la table");
            }
        }
    }
}

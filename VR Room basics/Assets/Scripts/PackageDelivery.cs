using UnityEngine;
using UnityEngine.Rendering;


public class PackageDelivery : MonoBehaviour
{
    private int time;
    private int event1;
    public GameObject package;
    public GameObject canva;
    public AudioSource sonnette;
    void Awake()
    {
        time = (int)Time.time;
        event1 = 20;
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
    
    
}

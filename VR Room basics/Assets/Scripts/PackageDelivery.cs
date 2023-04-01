using UnityEngine;


public class PackageDelivery : MonoBehaviour
{
    private int time;
    private int event1;
    public GameObject package,canva;
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
            package.SetActive(true);
            canva.SetActive(true);
            sonnette.Play();
        }
    }
    
    
}

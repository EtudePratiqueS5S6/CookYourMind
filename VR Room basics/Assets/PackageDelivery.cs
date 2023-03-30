using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PackageDelivery : MonoBehaviour
{
    private int time;
    private int event1;
    public GameObject packagePanel;
    public GameObject package;
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
            packagePanel.SetActive(true);
            package.SetActive(true);
            sonnette.Play();
        }
    }
    
    
}

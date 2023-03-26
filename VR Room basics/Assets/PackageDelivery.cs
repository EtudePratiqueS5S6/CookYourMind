using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PackageDelivery : MonoBehaviour
{
    private int time;
    private int event1;
    public GameObject package;
    public AudioSource sonnette;
    void Awake()
    {
        time = (int)Time.time;
        event1 = 120;
    }

    // Update is called once per frame
    void Update()
    {
        time = (int)Time.time;
        if (time == event1)
        {
            package.SetActive(true);
            sonnette.Play();
        }
    }
    
    
}

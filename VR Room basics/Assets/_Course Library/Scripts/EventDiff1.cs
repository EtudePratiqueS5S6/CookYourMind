using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EventDiff1 : MonoBehaviour
{
    public float time;

    public float event1 = 120f;

    public float event2 = 200f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        if ((int)time == (int)event1)
        {
           setCouverts(); 
        }
        
    }

    void setCouverts()
    {
        GameObject[] couverts = GameObject.FindGameObjectsWithTag("couverts");
        
        for (int i = 0; i < couverts.Length; i++)
        {
            Vector3 position = couverts[i].transform.position;
            //définir la position en fonction de i 
            couverts[i].transform.position = new Vector3((float)(position.x + math.pow(-1,i)*(i+1)*0.6), (float)0.6, (float)(position.x + math.pow(-1,i+1)*(i+1)*0.6));
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreRay : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, ~layerMask))
        {
            // Le rayon a frappé un objet qui n'est pas sur la couche "Ignore Raycast"
        }
    }
}

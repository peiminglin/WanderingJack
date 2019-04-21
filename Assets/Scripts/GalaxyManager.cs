using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyManager : MonoBehaviour
{
    public static GravitySource Galaxy;

    void Start()
    {
        Galaxy = GetComponent<GravitySource>();
    }

    void Update()
    {
        
    }
}

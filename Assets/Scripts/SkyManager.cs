using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkyManager : MonoBehaviour
{

    public float skySpeed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skySpeed);
    }
}

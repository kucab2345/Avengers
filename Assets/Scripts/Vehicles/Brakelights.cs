﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brakelights : MonoBehaviour {

    private Light tailLight;
    private float originalIntensity;

	// Use this for initialization
	void Start () {
        tailLight = GetComponent<Light>();
        originalIntensity = tailLight.intensity;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.root.gameObject.GetComponent<CarDriveable>().Throttle < 0)
        {
            tailLight.intensity = originalIntensity;
        }
        else
        {
            tailLight.intensity = 0f;
        }
    }
}

﻿using UnityEngine;
using System.Collections;

public class DieWhenAudioFinishes : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!audio.isPlaying)
            Destroy(gameObject);
	}
}

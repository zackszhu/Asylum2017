using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : InteractiveTrigger {

    public bool TVOn { get; private set; }

    [SerializeField] GameObject TVLight;
    [SerializeField] Renderer TVRenderer;
    [SerializeField] Material NoiseMat;
    [SerializeField] Material BlackMat;

    // Use this for initialization
    void Start () {
        TurnOnTV(false);
	}

    public void TurnOnTV (bool on) {
        if (on) {
            //TVPlayer.Play();
            TVRenderer.material = NoiseMat;
            TVLight.SetActive(true);
        } else {
            //TVPlayer.Stop();
            TVRenderer.material = BlackMat;
            TVLight.SetActive(false);
        }
    }
    
    protected override void InteractionDown () {
        
    }

    protected override void PlayerTriggerEnter () {
        TurnOnTV(true);
    }

    protected override void PlayerTriggerExit () {
        TurnOnTV(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}

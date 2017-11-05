using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TV : InteractiveTrigger {

    public bool TVOn { get; private set; }

    [SerializeField] GameObject TVLight;
    [SerializeField] Renderer TVRenderer;
    [SerializeField] Material NoiseMat;
    [SerializeField] Material BlackMat;
    [SerializeField] AudioSource NoiseAudio;

    [SerializeField] bool startState;
    [SerializeField] bool enterState;

    // Use this for initialization
    void Start () {
        TurnOnTV(startState);
	}

    public void TurnOnTV (bool on) {
        if (on) {
            //TVPlayer.Play();
            TVRenderer.material = NoiseMat;
            TVLight.SetActive(true);
            NoiseAudio.Play();
        } else {
            //TVPlayer.Stop();
            TVRenderer.material = BlackMat;
            TVLight.SetActive(false);
            NoiseAudio.Stop();
        }
    }
    
    protected override void InteractionDown () {
        
    }

    protected override void PlayerTriggerEnter () {
        TurnOnTV(enterState);
    }

    protected override void PlayerTriggerExit () {
        //TurnOnTV(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}

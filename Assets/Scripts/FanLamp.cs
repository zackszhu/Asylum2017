using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanLamp : InteractiveTrigger {

    public float AngularSpeed = 15f;
    public bool SpinEnabled = true;
    public bool LightEnabled = true;
    public bool LightOn { get; private set; }

    [SerializeField] Transform LeavesTransform;
    [SerializeField] Renderer BulbRenderer;
    [SerializeField] GameObject LampLight;
    [SerializeField] Material LampNormalMat;
    [SerializeField] Material LampLightMat;
    [SerializeField] AudioSource SwitchSound;

    // Use this for initialization
    void Start () {
        SetLightOn(false);
	}

    public void SwitchLightOn () {
        SetLightOn(!LightOn);
    }

    public void SetLightOn (bool on) {
        LightOn = on;
        if (on) {
            BulbRenderer.material = LampLightMat;
            LampLight.SetActive(true);
        } else {
            BulbRenderer.material = LampNormalMat;
            LampLight.SetActive(false);
        }
    }

    public IEnumerator LightFlashCoroutine () {
        SetLightOn(false);
        yield return new WaitForSeconds(0.1f);
        SetLightOn(true);
        yield return new WaitForSeconds(0.1f);
        SetLightOn(false);
        yield return new WaitForSeconds(0.1f);
        SetLightOn(true);
        yield return new WaitForSeconds(0.1f);
        SetLightOn(false);
    }
    
    protected override void InteractionDown () {
        if (LightEnabled) {
            SwitchSound.Play();
            Invoke("SwitchLightOn", 0.4f);
        }
    }

    protected override void PlayerTriggerEnter () {
        
    }

    protected override void PlayerTriggerExit () {
        
    }

    // Update is called once per frame
    void Update () {
		if (SpinEnabled) {
            LeavesTransform.Rotate(Vector3.up, Time.deltaTime * AngularSpeed);
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : InteractiveTrigger {

    public bool AllowTriggerFlash;
    public bool LightOn { get; private set; }

    private float LightIntensity;
    
    [SerializeField] Light LampLight;
    [SerializeField] AudioSource FlashAudio;

    // Use this for initialization
    void Start () {
        LightIntensity = LampLight.intensity;
    }

    public void FlashLight () {
        StartCoroutine(FlashCoroutine());
        FlashAudio.Play();
    }

    IEnumerator FlashCoroutine () {
        //float flashFactor = 0.5f;
        for (int i = 0; i < 5; i++) {
            LampLight.intensity = (Random.value / 2f + 0.25f) * LightIntensity;
            yield return new WaitForSeconds(0.06f * (Random.value / 2f + 0.75f));
            LampLight.intensity = 1f * LightIntensity;
            yield return new WaitForSeconds(0.07f * (Random.value / 2f + 0.75f));
        }
    }

    protected override void InteractionDown () {
        
    }

    protected override void PlayerTriggerEnter () {
        if (AllowTriggerFlash) {
            AllowTriggerFlash = false;
            FlashLight();
        }
    }

    protected override void PlayerTriggerExit () {
        
    }

    // Update is called once per frame
    void Update () {

	}
}

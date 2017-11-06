using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLight : MonoBehaviour {
    public Light LampLight;
    public float LightIntensity;

    private void Start() {
        FlashLight();
    }

    public void FlashLight() {
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine() {
        while (true) {
            //float flashFactor = 0.5f;
            for (int i = 0; i < 5; i++) {
                LampLight.intensity = (Random.value / 2f + 0.25f) * LightIntensity;
                yield return new WaitForSeconds(0.06f * (Random.value / 2f + 0.75f));
                LampLight.intensity = 1f * LightIntensity;
                yield return new WaitForSeconds(0.07f * (Random.value / 2f + 0.75f));
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
}

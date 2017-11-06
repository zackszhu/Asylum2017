using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColor : MonoBehaviour {
    public float OneMin;
    public float OneMax;
    public float TwoMin;
    public float TwoMax;
    public float ThreeMin;
    public float ThreeMax;

    public Color dark;
    public Color light;

    private void Update() {
        if (PlayerController.Instance.transform.position.x > OneMin && PlayerController.Instance.transform.position.x < OneMax
            || PlayerController.Instance.transform.position.x > TwoMin && PlayerController.Instance.transform.position.x < TwoMax
            || PlayerController.Instance.transform.position.x > ThreeMin && PlayerController.Instance.transform.position.x < ThreeMax) {
            if (RenderSettings.ambientLight != light) {
                RenderSettings.ambientLight = light;
                if (GameFlow.Instance.checkpointIndex == 0) {
                    EnvironmentSoundController.SetAmbientSound(EnvironmentSoundController.Instance.Outdoor_wind);
                }
                else {
                    EnvironmentSoundController.SetAmbientSound(EnvironmentSoundController.Instance.Outdoor_rain);
                }
                if (GameFlow.Instance.checkpointIndex == 1) {
                    Lightening.StartLightening();
                }
            }
        }
        else {
            if (RenderSettings.ambientLight != dark) {
                RenderSettings.ambientLight = dark;
                if (GameFlow.Instance.checkpointIndex == 0) {
                    EnvironmentSoundController.SetAmbientSound(EnvironmentSoundController.Instance.Indoor_wind);
                }
                else {
                    EnvironmentSoundController.SetAmbientSound(EnvironmentSoundController.Instance.Indoor_rain);
                }
            }
        }
    }

}

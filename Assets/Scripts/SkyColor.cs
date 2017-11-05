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
            RenderSettings.ambientLight = light;
        }
        else {
            RenderSettings.ambientLight = dark;
        }
    }

}

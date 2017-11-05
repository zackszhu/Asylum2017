using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightening : MonoBehaviour {

    private static Lightening Instance;
    private Color CameraDefaultColor;
    private Color LighteningColor;
    private float LightIntensity;

    [SerializeField] Camera MainCamera;
    [SerializeField] Light LighteningLight;
    [SerializeField] AudioSource LighteningAudio;

    private void Awake () {
        if (!Instance) Instance = this;
        else Debug.LogWarning("Multiple Lightening Detected");
    }

    private void Start () {
        CameraDefaultColor = MainCamera.backgroundColor;
        LighteningColor = Color.white;
        LightIntensity = LighteningLight.intensity;
        LighteningLight.enabled = true;
        LighteningLight.intensity = 0f;
    }

    public static void StartLightening () {
        Instance.StartCoroutine(Instance.LighteningCoroutine());
        Instance.LighteningAudio.Play();
    }

    IEnumerator LighteningCoroutine () {
        yield return new WaitForSeconds(0.8f);
        SetLightening(1f);
        yield return new WaitForSeconds(0.1f);
        SetLightening(0f);
        yield return new WaitForSeconds(0.1f);
        SetLightening(1f);
        yield return new WaitForSeconds(0.1f);
        SetLightening(0f);
        yield return new WaitForSeconds(0.4f);
        SetLightening(1f);
        yield return new WaitForSeconds(0.3f);
        SetLightening(0f);
    }

    private void SetLightening (float degree) {
        MainCamera.backgroundColor = Color.Lerp(CameraDefaultColor, LighteningColor, degree);
        LighteningLight.intensity = Mathf.Lerp(0f, LightIntensity, degree);
    }

    private void Update () {
        // test 
        if (Input.GetKeyDown(KeyCode.L)) {
            StartLightening();
        }
    }
}

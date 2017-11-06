using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

    private static Fader Instance;
    private static SpriteRenderer Renderer { get { return Instance.GetComponent<SpriteRenderer>(); } }

    private void Awake () {
        if (!Instance) Instance = this;
        else Debug.LogWarning("Multiple Fader detected");
    }

    public static void StartFadeIn (float duration = 2f) {
        Instance.StartCoroutine(FadeInCoroutine(duration));
    }

    public static void StartFadeOut (float duration = 2f) {
        Instance.StartCoroutine(FadeOutCoroutine(duration));
    }

    public static IEnumerator FadeInCoroutine (float duration = 2f) {
        float t = 0f;
        while (t < duration) {
            Renderer.color = new Color(0f, 0f, 0f, Mathf.Lerp(1f, 0f, t / duration));
            t += Time.deltaTime;
            yield return null;
        }
    }

    public static IEnumerator FadeOutCoroutine (float duration = 2f) {
        float t = 0f;
        while (t < duration) {
            Renderer.color = new Color(0f, 0f, 0f, Mathf.Lerp(0f, 1f, t / duration));
            t += Time.deltaTime;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update () {
		// test 
        if (Input.GetKeyDown(KeyCode.I)) {
            StartFadeOut();
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            StartFadeIn();
        }
    }
}

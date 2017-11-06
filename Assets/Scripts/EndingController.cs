using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingController : MonoBehaviour {

    [SerializeField] Camera MainCamera;
    [SerializeField] Material MotherMat;
    [SerializeField] AudioSource DialogAudio;
    [SerializeField] SpriteRenderer FaderSprite;
    [SerializeField] SpriteRenderer CreditsSprite;

    // Use this for initialization
    void Start () {
        MotherMat.color = new Color(1f, 1f, 1f, 0f);
        StartCoroutine(EndingCoroutine());
	}
	
    IEnumerator EndingCoroutine () {
        Color camInitColor = MainCamera.backgroundColor;
        float t = 0f, duration = 4f;
        while (t < duration) {
            MainCamera.backgroundColor = Color.Lerp(camInitColor, new Color(0.4f, 0.4f, 0.4f, 1f), t / duration);
            t += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        DialogAudio.Play();
        t = 0f;
        duration = 3.5f;
        while (t < duration) {
            MotherMat.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 0.6f, t / duration));
            t += Time.deltaTime;
            yield return null;
        }
        yield return new WaitUntil(() => !DialogAudio.isPlaying);
        t = 0f;
        duration = 4f;
        while (t < duration) {
            FaderSprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, t / duration));
            t += Time.deltaTime;
            yield return null;
        }
        CreditsSprite.enabled = true;
        t = 0f;
        duration = 3f;
        while (t < duration) {
            FaderSprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, t / duration));
            t += Time.deltaTime;
            yield return null;
        }
        yield return new WaitUntil(() => Input.anyKeyDown);
        t = 0f;
        duration = 1f;
        while (t < duration) {
            FaderSprite.color = new Color(0f, 0f, 0f, Mathf.Lerp(0f, 1f, t / duration));
            t += Time.deltaTime;
            yield return null;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
}

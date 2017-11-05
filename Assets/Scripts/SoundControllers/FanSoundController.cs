using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSoundController : MonoBehaviour {

    public AudioClip[] Clips;
    private new AudioSource audio { get { return GetComponent<AudioSource>(); } }
    private FanLamp fan { get { return transform.parent.GetComponent<FanLamp>(); } }

	// Use this for initialization
	void Start () {
        StartCoroutine(SoundCoroutine());
	}

    IEnumerator SoundCoroutine () {
        while (fan) {
            if (fan.SpinEnabled) {
                audio.clip = GetRandomClip();
                audio.Play();
            }
            yield return new WaitForSeconds(120f / fan.AngularSpeed);
        }
    }

    AudioClip GetRandomClip () {
        if (Clips.Length == 0) {
            Debug.Log("no fan sound");
            return null;
        }
        int index = Random.Range(0, Clips.Length);
        return Clips[index];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

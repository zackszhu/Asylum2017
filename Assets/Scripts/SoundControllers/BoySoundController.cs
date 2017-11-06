using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoySoundController : MonoBehaviour {

    private static BoySoundController Instance;

    [SerializeField] AudioSource BoyAudio;
    [SerializeField] AudioSource BreathAudio;
    [SerializeField] AudioClip wakeup, breath_normal, breath_run;
    [SerializeField] AudioClip[] emm;
    [SerializeField] AudioClip[] mommy;
    [SerializeField] AudioClip[] shocked;
    [SerializeField] AudioClip scream;

    private void Awake () {
        if (!Instance) Instance = this;
        else Debug.LogWarning("Multiple BoySound detected");
    }

    public static void PlayScream() {
        Instance.BoyAudio.clip = Instance.scream;
        Instance.BoyAudio.Play();
    }

    public static void PlayBreathNormal () {
        Instance.BreathAudio.clip = Instance.breath_normal;
        Instance.BreathAudio.Play();
    }

    public static void PlayBreathRun () {
        Instance.BreathAudio.clip = Instance.breath_run;
        Instance.BreathAudio.Play();
    }

    public static void StopBreath () {
        Instance.BreathAudio.Stop();
    }

    public static void PlayWakeUp () {
        Instance.BoyAudio.clip = Instance.wakeup;
        Instance.BoyAudio.Play();
    }

    public static void PlayEmm (int index = -1) { // -1 is random
        if (index >= 0 && index < Instance.emm.Length) {
            Instance.BoyAudio.clip = Instance.emm[index];
        } else {
            Instance.BoyAudio.clip = Instance.emm[Random.Range(0, Instance.emm.Length)];
        }
        Instance.BoyAudio.Play();        
    }

    public static void PlayMommy (int index = -1) { // -1 is random
        if (index >= 0 && index < Instance.mommy.Length) {
            Instance.BoyAudio.clip = Instance.mommy[index];
        } else {
            Instance.BoyAudio.clip = Instance.mommy[Random.Range(0, Instance.mommy.Length)];
        }
        Instance.BoyAudio.Play();
    }

    public static void PlayShocked (int index = -1) { // -1 is random
        if (index >= 0 && index < Instance.shocked.Length) {
            Instance.BoyAudio.clip = Instance.shocked[index];
        } else {
            Instance.BoyAudio.clip = Instance.shocked[Random.Range(0, Instance.shocked.Length)];
        }
        Instance.BoyAudio.Play();
    }
}

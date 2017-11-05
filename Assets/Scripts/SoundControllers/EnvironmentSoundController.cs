using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSoundController : MonoBehaviour {

    public static EnvironmentSoundController Instance { get; private set; }

    public AudioClip Indoor_wind, Outdoor_wind,
        Indoor_rain, Outdoor_rain;

    [SerializeField] AudioSource AmbientSource;

    public static void SetAmbientSound (AudioClip clip) {
        Instance.AmbientSource.clip = clip;
        Instance.AmbientSource.Play();
    }
}

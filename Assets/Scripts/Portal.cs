using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    [SerializeField] private float targetX;
    private bool Entered = false;

    private IEnumerator Transmit() {
        yield return StartCoroutine(Fader.FadeOutCoroutine());
        var pos = PlayerController.Instance.transform.position;
        pos.x = targetX;
        PlayerController.Instance.transform.position = pos;
        PlayerController.Instance.Calm();
        CameraController.Instance.ResetCamera();
        BoySoundController.PlayWakeUp();
        yield return StartCoroutine(Fader.FadeInCoroutine());
    }

    private void OnTriggerEnter(Collider other) {
        if (!Entered) {
            StartCoroutine(Transmit());
            Entered = true;
        }
    }
}

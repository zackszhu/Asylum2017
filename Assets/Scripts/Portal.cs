using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    [SerializeField] private float targetX;

    private void OnTriggerEnter(Collider other) {
        var pos = PlayerController.Instance.transform.position;
        pos.x = targetX;
        PlayerController.Instance.transform.position = pos;
        PlayerController.Instance.Calm();
        CameraController.Instance.ResetCamera();
        BoySoundController.PlayWakeUp();
    }
}

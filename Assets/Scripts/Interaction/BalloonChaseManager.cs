using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonChaseManager : MonoBehaviour {
    [SerializeField] BalloonMovement[] balloons;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            foreach (var balloon in balloons) {
                balloon.step = -1;
            }
        }
    }

}

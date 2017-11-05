using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DoorOpen : MonoBehaviour {
    [SerializeField]
    private Animator doorAnimator;
    [SerializeField]
    private bool lockAfterOpen;

    private bool canOpen = true;

    private string[] triggers = { "LeftOpen", "RightOpen" };

    private void OnTriggerEnter(Collider other) {
        doorAnimator.ResetTrigger("Close");
        if (other.CompareTag("Player")) {
            int index = Convert.ToInt32(other.transform.position.x > transform.position.x);
            if (index == 1 && !canOpen) return;
            doorAnimator.SetTrigger(triggers[index]);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            doorAnimator.SetTrigger("Close");
            if (lockAfterOpen) {
                canOpen = false;
            }
        }
    }
}

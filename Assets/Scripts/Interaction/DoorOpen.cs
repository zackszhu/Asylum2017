using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DoorOpen : MonoBehaviour {
    [SerializeField]
    private Animator doorAnimator;

    private string[] triggers = { "LeftOpen", "RightOpen" };

    private void OnTriggerEnter(Collider other) {
        doorAnimator.ResetTrigger("Close");
        if (other.CompareTag("Player")) {
            int index = Convert.ToInt32(other.transform.position.x > transform.position.x);
            doorAnimator.SetTrigger(triggers[index]);
        }
    }

    private void OnTriggerExit(Collider other) {
        doorAnimator.SetTrigger("Close");
    }
}

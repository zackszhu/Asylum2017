using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    [SerializeField]
    private Animator animator;

    private bool prevMoving;
    private bool currMoving;

    private bool prevRunning;
    private bool currRunning;

    void Update () {
        currMoving = PlayerController.Instance.IsMoving;
        if (currMoving != prevMoving) {
            animator.SetBool("isWalking", PlayerController.Instance.IsMoving);
        }
        currRunning = PlayerController.Instance.IsRunning;
        if (currRunning != prevRunning) {
            animator.SetBool("isRunning", PlayerController.Instance.IsRunning);
        }

    }

    private void LateUpdate() {
        prevMoving = currMoving;
        prevRunning = currRunning;
    }
}

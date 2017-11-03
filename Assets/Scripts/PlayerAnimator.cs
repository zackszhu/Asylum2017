using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    [SerializeField]
    private Animator animator;

    private bool prevMoving;
    private bool currMoving;

    void Update () {
        currMoving = PlayerController.Instance.IsMoving;
        if (currMoving != prevMoving) {
            animator.SetBool("isWalking", PlayerController.Instance.IsMoving);
        }
	}

    private void LateUpdate() {
        prevMoving = currMoving;
    }
}

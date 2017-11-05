using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour {
    private Rigidbody balloonRigidbody;
    [SerializeField] private Transform ballPosition;
    [SerializeField] private float targetX;
    [SerializeField] private float floatForce;
    [SerializeField] private float fleeForce;
    [SerializeField] private float chaseForce;
    [SerializeField] private float chaseMaxSpeed;
    [SerializeField] private Transform chaseTarget;
    [SerializeField] private Vector3 chaseTargetOffset;

    private Coroutine currCO;

    public int step = 0; // 0 for flee, 2 for chase

    private void Start() {
        balloonRigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (step != 3) {
            balloonRigidbody.AddForce(Vector3.up * floatForce);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (step == -1) {
                if (currCO != null)
                    StopCoroutine(currCO);
            }
            if (step == 0) {
                step = 1;
                currCO = StartCoroutine(FleeCO());
            }
            if (step == 2) {
                step = 3;
                currCO = StartCoroutine(ChaseCO());
            }
        }
    }

    private IEnumerator FleeCO() {
        while (ballPosition.position.x < targetX) {
            balloonRigidbody.AddForce(Vector3.right * fleeForce);
            yield return null;
        }
        step++;
    }

    private IEnumerator ChaseCO() {
        while (true) { // need variable
            balloonRigidbody.AddForce((chaseTarget.position + chaseTargetOffset - ballPosition.position) * chaseForce);
            balloonRigidbody.velocity = Mathf.Clamp(balloonRigidbody.velocity.magnitude, 0, chaseMaxSpeed) * balloonRigidbody.velocity.normalized;
            yield return null;
        }
        step++;
    }

}

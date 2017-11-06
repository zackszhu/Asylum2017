using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaocaoRenChase : InteractiveTrigger {
    public float distance;

    private void Start() {
        foreach (var rend in GetComponentsInChildren<Renderer>()) {
            rend.enabled = false;
        }
    }
    protected override void InteractionDown() {
    }

    protected override void PlayerTriggerEnter() {
    }

    protected override void PlayerTriggerExit() {
        if (PlayerController.Instance.transform.position.x >= transform.position.x) {
            //distance = PlayerController.Instance.transform.position.x - transform.position.x;
            StartCoroutine(Chase());
        }
    }

    private IEnumerator Chase() {
        while (GameFlow.Instance.checkpointIndex < 2) {
            var pos = PlayerController.Instance.transform.position - distance * Vector3.right;
            if (pos.x >= transform.position.x) {
                transform.position = pos;
            }
            if (PlayerController.Instance.transform.position.x - transform.position.x < 0.2f) {
                GameFlow.Instance.Die();
            }
            yield return null;
        }
        InteractiveEnabled = false;

    }

}

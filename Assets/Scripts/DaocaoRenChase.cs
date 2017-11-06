using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaocaoRenChase : InteractiveTrigger {

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
            StartCoroutine(Chase());
        }
    }

    private IEnumerator Chase() {
        while (transform.position.x < PlayerController.Instance.transform.position.x && GameFlow.Instance.checkpointIndex < 2) {
            transform.Translate(Vector3.forward * 3 * Time.deltaTime);
            yield return null;
        }
        if (transform.position.x >= PlayerController.Instance.transform.position.x) {
            GameFlow.Instance.Die();
        }
        InteractiveEnabled = false;

    }

}

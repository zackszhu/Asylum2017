using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaocaoRenNormal : InteractiveTrigger {
    [SerializeField] private float duration;

    protected override void InteractionDown() {
        
    }

    protected override void PlayerTriggerEnter() {
        TextController.ShowText(TextController.ScarecrowText);
    }

    protected override void PlayerTriggerExit() {
        TextController.HideText();
        if (PlayerController.Instance.transform.position.x >= transform.position.x) {
            PlayerController.Instance.Frightened();
            StartCoroutine(TurnAround());
        }

    }

    private IEnumerator TurnAround() {
        var t = 0f;
        while (t < duration) {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, - 90f / duration * t + 45, 0);
            yield return null;
        }
        InteractiveEnabled = false;

    }
}

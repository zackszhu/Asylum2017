using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : InteractiveTrigger {

    [SerializeField] GameObject UIPress;
    [SerializeField] BoxCollider coll;


    protected override void InteractionDown() {
        InteractiveEnabled = false;
        StartCoroutine(DownCO());
    }

    private IEnumerator DownCO() {
        if (coll != null) {
            coll.enabled = false;
        }
        yield return StartCoroutine(PlayerController.Instance.GoInto());
        if (coll != null) {
            coll.enabled = true;
        }
        GetComponent<Animator>().SetTrigger("Open");
        Invoke("Disappear", 0.3f);
        yield return StartCoroutine(GoOut());
    }

    private void Disappear() {
        PlayerController.Instance.GoAndDisappear();
    }

    private IEnumerator GoOut() {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        if (coll != null) {
            coll.enabled = false;
        }
        PlayerController.Instance.Calm();
        GetComponent<Animator>().SetTrigger("Open");
        yield return StartCoroutine(PlayerController.Instance.GoOut());
        if (coll != null) {
            coll.enabled = true;
        }
        InteractiveEnabled = true;
    }

    protected override void PlayerTriggerEnter() {
        if (UIPress) UIPress.SetActive(true);
    }

    protected override void PlayerTriggerExit() {
        if (UIPress) UIPress.SetActive(false);
    }
}

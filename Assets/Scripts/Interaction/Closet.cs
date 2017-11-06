using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : InteractiveTrigger {

    [SerializeField] GameObject UIPress;

    protected override void InteractionDown() {
        InteractiveEnabled = false;
        StartCoroutine(DownCO());
    }

    private IEnumerator DownCO() {
        yield return StartCoroutine(PlayerController.Instance.GoInto());
        GetComponent<Animator>().SetTrigger("Open");
        Invoke("Disappear", 0.3f);
        yield return StartCoroutine(GoOut());
    }

    private void Disappear() {
        PlayerController.Instance.GoAndDisappear();
    }

    private IEnumerator GoOut() {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        PlayerController.Instance.Calm();
        GetComponent<Animator>().SetTrigger("Open");
        yield return StartCoroutine(PlayerController.Instance.GoOut());
        InteractiveEnabled = true;
    }

    protected override void PlayerTriggerEnter() {
        if (UIPress) UIPress.SetActive(true);
    }

    protected override void PlayerTriggerExit() {
        if (UIPress) UIPress.SetActive(false);
    }
}

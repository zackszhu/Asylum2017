using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractiveTrigger : InteractiveTrigger {

    // Use this for initialization
    void Start () {
        InteractiveEnabled = true;
        TriggerEnabled = true;
    }

    protected override void InteractionDown () {
        Debug.Log("Fuck");
    }

    protected override void PlayerTriggerEnter () {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    protected override void PlayerTriggerExit () {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}

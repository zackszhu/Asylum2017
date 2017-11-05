using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveTrigger : MonoBehaviour {
    [SerializeField]
    protected bool TriggerEnabled = true;
    protected bool InteractiveEnabled = true;

	// Use this for initialization
	void Start () {
		
	}

    abstract protected void InteractionDown ();

    abstract protected void PlayerTriggerEnter ();

    abstract protected void PlayerTriggerExit ();

    private void DetectInteraction () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (InteractiveEnabled) InteractionDown();
        }
    }

    private void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            if (TriggerEnabled) PlayerTriggerEnter();
        }
    }

    private void OnTriggerStay (Collider other) {
        if (other.tag == "Player") {
            if (TriggerEnabled) DetectInteraction();
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.tag == "Player") {
            if (TriggerEnabled) PlayerTriggerExit();
        }
    }
}

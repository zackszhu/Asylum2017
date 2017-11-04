using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour { // TEST

    private bool TriggerEnabled = false;

	// Use this for initialization
	void Start () {
		
	}

    private void DetectInteraction () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Fuck");
        }
    }

    private void OnTriggerStay (Collider other) {
        if (other.tag == "Player") {
            TriggerEnabled = true;
            transform.GetChild(0).gameObject.SetActive(true); // TEST
            DetectInteraction();
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.tag == "Player") {
            TriggerEnabled = false;
            transform.GetChild(0).gameObject.SetActive(false); // TEST
        }
    }
}

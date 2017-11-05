using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFan : InteractiveTrigger {
    private Rigidbody rigid;

    protected override void InteractionDown() {
    }

    protected override void PlayerTriggerEnter() {
        rigid.useGravity = true;
    }

    protected override void PlayerTriggerExit() {
    }

    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

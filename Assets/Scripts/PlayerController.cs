using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController Instance { get; private set; }

    private CharacterController controller;

    private void Awake () {
        if (!Instance) Instance = this;
        else Debug.LogWarning("Multiple player detected");
    }

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        if (!controller) Debug.LogWarning("No CharacterController");
    }

    private void InputUpdate () { // TEST
        if (Input.GetKey(KeyCode.LeftArrow)) {

        }
        if (Input.GetKey(KeyCode.RightArrow)) {

        }
    }

    // Update is called once per frame
    void Update () {
        InputUpdate();
    }
}

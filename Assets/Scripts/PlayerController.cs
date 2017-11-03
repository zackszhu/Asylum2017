using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController Instance { get; private set; }

    public float MoveSpeed = 2.5f;
    public bool FaceForward { get; private set; }
    public bool IsMoving { get; private set; }

    private CharacterController controller;

    private void Awake () {
        if (!Instance) Instance = this;
        else Debug.LogWarning("Multiple PlayerController detected");
    }

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        if (!controller) Debug.LogWarning("No CharacterController");

        IsMoving = false;
        FaceForward = true;
    }

    private void InputUpdate () { // TEST
        float movement = Input.GetAxis("Horizontal");
        controller.SimpleMove(new Vector3(MoveSpeed * movement, 0f, 0f));

        if (movement == 0f) {
            IsMoving = false;
        } else {
            IsMoving = true;
            if (movement > 0f) {
                FaceForward = true;
            } else {
                FaceForward = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        InputUpdate();
    }
}

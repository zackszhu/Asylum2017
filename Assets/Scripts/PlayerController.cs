using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController Instance { get; private set; }
    
    public float MoveSpeed = 2.5f;
    public bool MoveEnbled { get; private set; }
    public bool FaceForward { get; private set; }
    private bool prevForward;
    public bool IsMoving { get; private set; }

    private Quaternion backwardQuaternion;

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
        MoveEnbled = true;
        backwardQuaternion = Quaternion.Euler(new Vector3(0, 180, 0));
    }

    public void SetMoveEnabled(bool enabled) {
        if (enabled != MoveEnbled) {
            MoveEnbled = enabled;
            // possible other stuff
        }
    }

    private void InputUpdate () { 
        float movement = Input.GetAxis("Horizontal");
        controller.SimpleMove(new Vector3(MoveSpeed * movement, 0f, 0f));

        if (movement == 0f) {
            IsMoving = false;
        } else {
            IsMoving = true;
            if (movement > 0f) {
                if (!prevForward) {
                    FaceForward = true;
                    transform.rotation = Quaternion.identity;
                }
            } else {
                if (prevForward) {
                    FaceForward = false;
                    transform.rotation = backwardQuaternion;
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (MoveEnbled) {
            InputUpdate();
        }
    }
    private void LateUpdate() {
        prevForward = FaceForward;
    }
}

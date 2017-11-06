using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController Instance { get; private set; }
    
    public float MoveSpeed = 2f;
    public float RunSpeed = 3f;
    public float WalkSpeed = 2f;
    public bool MoveEnbled { get; private set; }
    public bool FaceForward { get; private set; }
    private bool prevForward;
    public bool IsMoving { get; private set; }
    public bool IsHiding { get; private set; }

    public bool IsRunning;

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
        BoySoundController.PlayBreathNormal();
    }

    public void Hide () {
        IsHiding = true;
        SetMoveEnabled(false);
        // TODO animation
    }

    public void Appear () {
        IsHiding = false;
        SetMoveEnabled(true);
        // TODO animation
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

    public void Shock() {
        BoySoundController.PlayShocked();
    }

    public void Frightened() {
        IsRunning = true;
        MoveSpeed = RunSpeed;
        BoySoundController.PlayShocked();
        BoySoundController.PlayBreathRun();
    }

    public void Calm() {
        IsRunning = false;
        MoveSpeed = WalkSpeed;
        BoySoundController.PlayBreathNormal();
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

    public IEnumerator GoInto() {
        MoveEnbled = false;
        IsMoving = true;
        transform.forward = Vector3.left;
        while (transform.position.z < 3f) {
            controller.SimpleMove(new Vector3(0f, 0f, MoveSpeed));
            yield return null;
        }
        IsMoving = false;
        IsHiding = true;
    }

    public void GoAndDisappear() {
        foreach (var render in GetComponentsInChildren<Renderer>()) {
            render.enabled = false;
        }
    }

    public IEnumerator GoOut() {
        MoveEnbled = false;
        IsMoving = true;
        foreach (var render in GetComponentsInChildren<Renderer>()) {
            render.enabled = true;
        }
        transform.forward = Vector3.right;
        IsHiding = false;
        while (transform.position.z > -1) {
            controller.SimpleMove(new Vector3(0f, 0f, -MoveSpeed));
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        transform.forward = Vector3.forward;
        MoveEnbled = true;
        IsMoving = false;
    }
}

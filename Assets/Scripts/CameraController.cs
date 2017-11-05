using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public static CameraController Instance { get; private set; }

    public bool FollowEnabled { get; private set; }
    [SerializeField] float DirectionBias = 3f;
    [SerializeField] float SpeedCoef = 4f;
    private Vector3 PlayerRelCenterPos;

    private PlayerController player;

    private void Awake () {
        if (!Instance) Instance = this;
        else Debug.LogWarning("Multiple CameraController detected");
    }

    public void ResetCamera() {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        PlayerRelCenterPos = transform.position - player.transform.position;
    }

    // Use this for initialization
    IEnumerator Start () {
        player = PlayerController.Instance;
        yield return null;
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        PlayerRelCenterPos = transform.position - player.transform.position;

        FollowEnabled = true;
	}

    public void SetFollowEnabled(bool enabled) {
        if (enabled != FollowEnabled) {
            FollowEnabled = enabled;
            // possible other stuff
        }
    }

    private void MoveToUpdate (Vector3 pos) {
        Vector3 rel = pos - transform.position;
        if (rel.magnitude < 0.05f) return;
        transform.Translate(Mathf.Sqrt(rel.magnitude * 2f) * rel.normalized * SpeedCoef * Time.deltaTime); // sqrt
        //transform.Translate(rel * SpeedCoef * Time.deltaTime); // Linear
        //transform.Translate(rel.magnitude * rel * SpeedCoef * Time.deltaTime); // square
    }

    private void FollowUpdate () {
        if (player.FaceForward) {
            MoveToUpdate(player.transform.position + PlayerRelCenterPos + Vector3.right * DirectionBias);
        } else {

            MoveToUpdate(player.transform.position + PlayerRelCenterPos + Vector3.left * DirectionBias);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (FollowEnabled) {
            FollowUpdate();
        }
	}
}

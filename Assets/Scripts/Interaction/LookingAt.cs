using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAt : MonoBehaviour {
    [SerializeField]
    private Transform target;

    private void Update() {
        transform.LookAt(target);
    }

}

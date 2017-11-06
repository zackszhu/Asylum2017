using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            PlayerController.Instance.SetMoveEnabled(false);
            GameFlow.Instance.GetComponent<SkyColor>().enabled = false;
            SceneManager.LoadScene(2);
        }
    }
}

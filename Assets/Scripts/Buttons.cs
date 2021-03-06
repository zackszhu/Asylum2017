﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

    public void NextScene() {
        SceneManager.LoadScene(1);
        GameFlow.Instance.GetComponent<SkyColor>().enabled = true;
    }

    public void ExitGame() {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamlyPic : MonoBehaviour {

    [SerializeField] Material NormalMat;
    [SerializeField] Material HorrorMat;

    [SerializeField] Renderer PicRenderer;

    // Use this for initialization
    void Start () {
		
	}

    private void ShowHorror(bool show) {
        if (show) {
            PicRenderer.material = HorrorMat;
        } else {
            PicRenderer.material = NormalMat;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.H)) {
            ShowHorror(true);
        }
	}
}

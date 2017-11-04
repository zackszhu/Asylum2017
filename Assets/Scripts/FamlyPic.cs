using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamlyPic : MonoBehaviour {

    [SerializeField] Material NormalMat;
    [SerializeField] Material HorrorMat;

    [SerializeField] Renderer PicRenderer;
    
    public IEnumerator FlashHorrorCoroutine () {
        ShowHorror(true);
        yield return new WaitForSeconds(0.1f);
        ShowHorror(false);
        yield return new WaitForSeconds(0.1f);
        ShowHorror(true);
        yield return new WaitForSeconds(0.1f);
        ShowHorror(false);
        yield return new WaitForSeconds(0.1f);
        ShowHorror(true);
        yield return new WaitForSeconds(0.2f);
        ShowHorror(false);
    }

    public void ShowHorror(bool show) {
        if (show) {
            PicRenderer.material = HorrorMat;
        } else {
            PicRenderer.material = NormalMat;
        }
    }
	
	// Update is called once per frame
	void Update () {
        // TEST
		if (Input.GetKeyDown(KeyCode.H)) {
            StartCoroutine(FlashHorrorCoroutine());
        }
	}
}

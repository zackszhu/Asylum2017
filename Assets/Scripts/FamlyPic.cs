using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamlyPic : InteractiveTrigger {

    public bool AllowTriggerHoror;

    [SerializeField] Material NormalMat;
    [SerializeField] Material HorrorMat;

    [SerializeField] Renderer PicRenderer;
    
    public IEnumerator FlashHorrorCoroutine () {
        ShowHorror(true);
        yield return new WaitForSeconds(0.1f);
        ShowHorror(false);
        yield return new WaitForSeconds(0.15f);
        ShowHorror(true);
    }

    public void ShowHorror(bool show) {
        if (show) {
            PicRenderer.material = HorrorMat;
        } else {
            PicRenderer.material = NormalMat;
        }
    }

    protected override void InteractionDown () {
        
    }

    protected override void PlayerTriggerEnter () {
        
    }

    protected override void PlayerTriggerExit () {
        if (AllowTriggerHoror) {
            AllowTriggerHoror = false;
            StartCoroutine(FlashHorrorCoroutine());
        }
    }

    // Update is called once per frame
    void Update () {
        
	}
}

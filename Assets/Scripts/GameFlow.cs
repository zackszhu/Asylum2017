using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameFlow : MonoBehaviour {
    public static GameFlow Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            return;
            //Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private float[] checkpoints;

    public int checkpointIndex;
    private Coroutine reloadCO;

    private bool isDied = false;

    private void Update() {
        if (checkpointIndex + 1 < checkpoints.Length && PlayerController.Instance.transform.position.x > checkpoints[checkpointIndex + 1]) {
            checkpointIndex++;
        }
    }

    public void Die() {
        if (isDied) return;
        BoySoundController.PlayScream();
        var pos = PlayerController.Instance.transform.position;
        pos.x = checkpoints[checkpointIndex];
        pos.z = -1;
        if (reloadCO == null) {
            Fader.Die();
            reloadCO = StartCoroutine(LoadYourAsyncScene(pos));
        }
        isDied = true;
    }

    IEnumerator LoadYourAsyncScene(Vector3 pos) {
        yield return StartCoroutine(Fader.FadeOutCoroutine());
        //Fader.Die();

        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone) {
            yield return null;
        }
        PlayerController.Instance.transform.position = pos;
        yield return StartCoroutine(Fader.FadeInCoroutine());
        isDied = false;
        reloadCO = null;
    }
}

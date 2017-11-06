using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

    private static TextController Instance;
    private TextMesh Text { get { return GetComponent<TextMesh>(); } }

    public static string WhereIsMom { get { return "It's a bad nightmare... where is mom? I need you..."; } }
    public static string FanText { get { return "Mom used to say: don't stand under the fan, or it will drop..."; } }
    public static string ClosetText { get { return "I love to stay inside the closet...I feel safe..."; } }
    public static string BalloonText { get { return "I hate balloons because once I was terrified by some balloons of clown faces..."; } }
    public static string ScarecrowText { get { return "I feel the scarecrow is looking at me..."; } }
    public static string ScaredText1 { get { return "Oh no!"; } }
    public static string ScaredText2 { get { return "MOM! Help me!!"; } }

    // Use this for initialization
    void Start () {
        Instance = this;
	}
	
	public static void ShowText(string text) {
        Instance.Text.text = text;
    }

    public static void HideText () {
        Instance.Text.text = "";
    }
}

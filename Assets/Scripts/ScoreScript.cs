using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public static int scoreValue = 0;
    public static int scoreValueLevel1 = 0;
    Text score;

    void Start() {
            score = GetComponent<Text> ();
    }

    void Update() {
        score.text = "Score: " + scoreValue;
    }
}
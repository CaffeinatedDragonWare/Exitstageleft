using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreBox;
    int score = 0;
    public static string highScoreBox = "High Score: 000000000";
    public static string yourScoreBox = "Your Score: 000000000";
    float scoreUpdateInterval = 0;
    int placeHolderLimit = 10;
    string placeHolders = "00000000";
    string highScorePlaceHolders = "0000";
    int highScore = 10000;
    // Start is called before the first frame update
    void Start() {
      scoreBox.text = "000000000"; // nine 0s
    }

    // Update is called once per frame
    void Update() {

      scoreUpdateInterval += Time.deltaTime;

      if (scoreUpdateInterval > 0.1 && Gameover.GameOver == false && ropeLift.GameStarted == false) {
        scoreUpdateInterval = 0;
        score += 1;

        if (score == placeHolderLimit) {
          placeHolders = placeHolders.Remove(placeHolders.Length-1);
          placeHolderLimit *= 10;
        }

        if (score > highScore) {
          highScore = score;
          highScorePlaceHolders = placeHolders;
        }

        scoreBox.text = placeHolders + score;

      }

      if (Gameover.GameOver == true) {
        yourScoreBox = "Your Score: " + placeHolders + score;
        highScoreBox = "High Score: " + highScorePlaceHolders + highScore;
      }

    }
}

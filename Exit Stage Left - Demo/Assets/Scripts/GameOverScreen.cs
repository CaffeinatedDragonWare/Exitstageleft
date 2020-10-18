using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {

    public Text highScoreBox;
    public Text yourScoreBox;

    // Start is called before the first frame update
    void Start() {
      highScoreBox.text = Score.highScoreBox;
      yourScoreBox.text = Score.yourScoreBox;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterFill : MonoBehaviour {

    float attention = 0f;
    public Vector2 MeterFillSize;
    public Vector2 MeterFillOffset;
    float FillSizeY = 0.065f;
    float FillOffsetY = 0.66f;
    int level = 0;
    int levelIncrease = 20;
    bool barFull = false;

    // Update is called once per frame
    void Update() {

      if (Score.score > level && barFull == false) {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.01f);
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.01f);
        level += levelIncrease;
      }

      if (transform.localScale.y >= 0.247f) {
        attentionMeter.attention = 2;
        levelIncrease = 100;
      }

      if (transform.localScale.y >= 0.747f) {
        attentionMeter.attention = 3;
        levelIncrease = 200;
      }

      if (transform.localScale.y >= 1.19f) {
        barFull = true;
      }
    }
}

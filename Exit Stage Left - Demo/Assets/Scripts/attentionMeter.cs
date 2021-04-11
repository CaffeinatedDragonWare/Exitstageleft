using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attentionMeter : MonoBehaviour {

    // sprites
    public Sprite bummer;
    public Sprite average;
    public Sprite hype;

    public static float attention = 0f;

    // Start is called before the first frame update
    void Start() {
      this.gameObject.GetComponent<SpriteRenderer>().sprite = bummer;
    }

    // Update is called once per frame
    void Update() {

      if (attention < 1) {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = bummer;
      }

      if (attention == 2) {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = average;
      }

      if (attention == 3) {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = hype;
      }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propWarning : MonoBehaviour {

    public GameObject env007stageHand;
    float x = 4.2f; // x value
    float y = 0.12f; // y value

    // Start is called before the first frame update
    void Start() {
      if (pendulum.command == "left") {
        transform.position = new Vector2(-x, y);
      }

      else if (pendulum.command == "right") {

      }
    }

    // Update is called once per frame
    void Update() {

    }
}

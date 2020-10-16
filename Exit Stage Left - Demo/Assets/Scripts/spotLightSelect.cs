﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotLightSelect : MonoBehaviour {

    private Vector2 startTouchPosition, endTouchPosition;
    public static float x = 0f;
    public static bool selection = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

      if (selection == false) {

          if (Input.touchCount > 0) {

    		      startTouchPosition = Input.GetTouch(0).position;
              x = (startTouchPosition.x / 200) - 4.9f;
              spawnPoints();

          }

          if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {

    		      endTouchPosition = Input.GetTouch(0).position;
              x = (endTouchPosition.x / 200) - 4.9f;
              spawnPoints();
              selection = true;
            }

        }

        if (selection == true) {
          GameObject player = GameObject.FindGameObjectWithTag("Player");
          transform.position = new Vector2(player.transform.position.x, 2.25f);
        }

    }

    void spawnPoints() {

      if (x < -1.875) {
        x = -2.5f;
      }

      if (x >= -1.875 && x < -0.625) {
        x = -1.25f;
      }

      if (x >= -0.625 && x < 0.625) {
        x = 0f;
      }

      if (x >= 0.625 && x < 1.875) {
        x = 1.25f;
      }

      if (x >= 1.875) {
        x = 2.5f;
      }

      transform.position = new Vector2(x, 2.25f);
    }
}
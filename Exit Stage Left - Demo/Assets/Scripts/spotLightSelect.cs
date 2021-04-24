using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotLightSelect : MonoBehaviour {

    private Vector2 startTouchPosition, endTouchPosition;
    public static float x = 0f;
    public static bool selection = false;
    int displayWidth;
    float touchRatio;

    void Start() {
      displayWidth = Display.main.systemWidth;
      touchRatio = displayWidth / 9.6f;
    }

    // Update is called once per frame
    void Update() {

      if (selection == false) {

          if (Input.touchCount > 0) {

    		      startTouchPosition = Input.GetTouch(0).position;
              x = (startTouchPosition.x / touchRatio) - 4.9f;
              spawnPoints();

          }

          if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {

    		      endTouchPosition = Input.GetTouch(0).position;
              x = (endTouchPosition.x / touchRatio) - 4.9f;
              spawnPoints();
              // selection = true;
            }

        }

        if (selection == true && ropeLift.GameStarted == false) { // fixed weird character stuck/crashing issue

          GameObject player = GameObject.FindGameObjectWithTag("Player");
          transform.position = new Vector2(player.transform.position.x, 2.15f);
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

      transform.position = new Vector2(x, 2.15f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour {

    public static float pushDirection = 0;
    public static bool GameOver = false;
    Transform LeftCurtain, RightCurtain;
    float x;
    //int count = 0;
    bool changed = false;


    void Start() {
      LeftCurtain = GameObject.Find("LeftCurtain").GetComponent<Transform> ();
      RightCurtain = GameObject.Find("RightCurtain").GetComponent<Transform> ();
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter2D(Collision2D collision) {
        // if (collision.gameObject.tag == "enemy") {
        //   GameOver = true;
        //
        // }

        if (collision.gameObject.tag == "Player" && GameOver == false) {

          foreach(ContactPoint2D hitPos in collision.contacts) {

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("Hit cords: " + hitPos.normal);
            pushDirection = hitPos.normal.x;
            GameOver = true;
            x = player.transform.position.x;
            //count = 0;

          }

        }

            //Physics2D.IgnoreLayerCollision(8, 8, false);

//            if (movingRight == true && PlayerPushed == false){
//              PlayerPushedRight = true;
//            }
//
//            PlayerPushed = true;

//        if (collision.gameObject.tag != "Player" && PlayerPushed == true) {
//          Physics2D.IgnoreLayerCollision(8, 8, true);
//          PlayerPushed = false;
//        }

    }

    void Update() {

      GameObject player = GameObject.FindGameObjectWithTag("Player");

      if (player.transform.position.x > RightCurtain.position.x ^ player.transform.position.x < LeftCurtain.position.x) {
        Application.LoadLevel("Gameover");
        GameOver = false;
        spotLightSelect.selection = false;
        ropeLift.GameStarted = true;
      }


      // if(GameOver == true && ropeLift.GameStarted == false) {
      //
      //   if(player.transform.position.x == x && count > 7 && changed == false) {
      //
      //     // during game over all enemies move left
      //     if (Gameover.pushDirection < 0) {
      //       enemyMovement.movingRight = false;
      //       changed = true;
      //     }
      //
      //     // during game over all enemies move right
      //     if (Gameover.pushDirection > 0) {
      //       enemyMovement.movingRight = true;
      //       changed = true;
      //     }
      //   }
      // }

      //count++;
    }
}

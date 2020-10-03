using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour {

    public static float pushDirection = 0;
    public static bool GameOver = false;
    Transform LeftCurtain, RightCurtain;


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

        if (collision.gameObject.tag == "Player") {

          foreach(ContactPoint2D hitPos in collision.contacts) {

            Debug.Log("Hit cords: " + hitPos.normal);
            pushDirection = hitPos.normal.x;
            GameOver = true;
            // StartCoroutine(delay());

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
      }

    }

    // IEnumerator delay() {
    //     yield return new WaitForSeconds(3);
    //     Application.LoadLevel("Gameover");
    //     GameOver = false;
    // }
}

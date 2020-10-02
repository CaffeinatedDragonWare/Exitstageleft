using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

    public float speed = 1f;
    Transform LeftCurtain, RightCurtain;
    Vector3 localScale;
    Rigidbody2D rb;
    bool movingRight = false;
    //public static bool PlayerPushed = false;
    bool directionSet = false;

    // Start is called before the first frame update
    void Start() {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D> ();
        LeftCurtain = GameObject.Find("LeftCurtain").GetComponent<Transform> ();
        RightCurtain = GameObject.Find("RightCurtain").GetComponent<Transform> ();
    }

    // Update is called once per frame
    void Update() {

        if (Gameover.GameOver == true && directionSet == false) {

          // during game over all enemies move right
          if (Gameover.pushDirection < 0) {
            movingRight = true;
          }

          // during game over all enemies move left
          if (Gameover.pushDirection > 0) {
            movingRight = false;
          }

          directionSet = true;

        }

        if (Movement.gameStarted == false) {

        }

        // sets normal movement direction
        else if (transform.position.x > RightCurtain.position.x && directionSet == false) { // move left
          movingRight = false;
        }

        else if (transform.position.x < LeftCurtain.position.x && directionSet == false) { // move right
          movingRight = true;
        }

        // makes enemies move in set direction
        if (movingRight == true && Movement.gameStarted == true) {
          moveRight();
        }

        else if (movingRight == false && Movement.gameStarted == true) {
          moveLeft();
        }

        // despawns enemies once they reach the other side of the screen
        if (enemiesSpawn.birthplace[0] == RightCurtain.position.x && transform.position.x <     LeftCurtain.position.x) { // move left
          Destroy(gameObject);
          enemiesSpawn.birthplace.RemoveAt(0);
          enemiesSpawn.enemiesSpawned.RemoveAt(0);

        }

        else if (enemiesSpawn.birthplace[0] == LeftCurtain.position.x && transform.position.x >     RightCurtain.position.x) { // move right
          Destroy(gameObject);
          enemiesSpawn.birthplace.RemoveAt(0);
          enemiesSpawn.enemiesSpawned.RemoveAt(0);
        }

    }

    void moveRight() {

      movingRight = true;
      localScale.x = 1;
      transform.localScale = localScale;
      rb.velocity = new Vector2 (localScale.x * speed, rb.velocity.y);
    }

    void moveLeft() {

      movingRight = false;
      localScale.x = -1;
      transform.localScale = localScale;
      rb.velocity = new Vector2 (localScale.x * speed, rb.velocity.y);

    }

}

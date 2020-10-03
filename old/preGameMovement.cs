using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preGameMovement : MonoBehaviour {

    public float speed = 1f;
    Vector3 localScale;
    Rigidbody2D rb;
    bool movingRight = false;

    // Start is called before the first frame update
    void Start() {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update() {

        if (transform.position.x > 1f) { // move left
          movingRight = false;
        }

        if (transform.position.x < -1f) { // move right
          movingRight = true;
        }

        if (transform.position.x == 1f) {
          movingRight = true;
        }

        if (transform.position.x == -1f) {
          movingRight = false;
        }

        // makes enemies move in set direction
        // if (movingRight == true && Movement.gameStarted == false) {
        //   moveRight();
        // }
        //
        // else if (movingRight == false && Movement.gameStarted == false) {
        //   moveLeft();
        // }

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

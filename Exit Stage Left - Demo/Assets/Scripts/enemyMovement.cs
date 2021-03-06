﻿using System.Collections;
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

        if (Gameover.GameOver == true && directionSet == false && ropeLift.GameStarted == false) {

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

        // sets normal movement direction
        else if (transform.position.x > RightCurtain.position.x && Gameover.GameOver == false) { // move left
          movingRight = false;
        }

        else if (transform.position.x < LeftCurtain.position.x && Gameover.GameOver == false) { // move right
          movingRight = true;
        }

        // makes enemies move in set direction
        if (movingRight == true && ropeLift.GameStarted == false) { // && Movement.gameStarted == true
          moveRight();
        }

        else if (movingRight == false && ropeLift.GameStarted == false) { // && Movement.gameStarted == true
          moveLeft();
        }

        // despawns enemies once they reach the other side of the screen
        if (enemiesSpawn.birthplace[0] == RightCurtain.position.x && transform.position.x < LeftCurtain.position.x) {
          Destroy(gameObject);
          enemiesSpawn.birthplace.RemoveAt(0);
          enemiesSpawn.enemiesSpawned -= 1;
        }

        else if (enemiesSpawn.birthplace[0] == LeftCurtain.position.x && transform.position.x > RightCurtain.position.x) {
          Destroy(gameObject);
          enemiesSpawn.birthplace.RemoveAt(0);
          enemiesSpawn.enemiesSpawned -= 1;
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

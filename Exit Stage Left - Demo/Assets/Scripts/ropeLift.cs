using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeLift : MonoBehaviour {

    Vector3 localScale;
    Rigidbody2D rb;
    int speed = 4;
    float landing = 0;

    void Start() {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update() {

      GameObject player = GameObject.FindGameObjectWithTag("Player");

      if (player.transform.position.y < 0.016) {
        //Physics2D.gravity = Vector2.zero;
        moveUp();
      }
    }

    void moveUp() {
      localScale.y = 1;
      transform.localScale = localScale;
      rb.velocity = new Vector2 (0, localScale.y * speed);
    }

}

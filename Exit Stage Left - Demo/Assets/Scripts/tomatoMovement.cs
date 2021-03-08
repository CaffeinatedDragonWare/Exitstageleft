using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomatoMovement : MonoBehaviour {

    float nextMove = 2f;
    float speed = 0.2f;
    Vector2 target;
    Vector2 startPosition;

    void Start() {
      GameObject player = GameObject.FindGameObjectWithTag("Player");
      target = new Vector2(player.transform.position.x, player.transform.position.y);
      startPosition = new Vector2(transform.position.x, transform.position.y);
      Debug.Log("Start x: " + startPosition.x + " Target: " + target.x);
    }

    void Update() {

      if (Time.time > nextMove) {

      transform.position = new Vector2(target.x * speed, 0f);
      transform.localScale = new Vector3(transform.localScale.x * 0.9f, transform.localScale.y * 0.9f, transform.localScale.z * 0.9f);

      Debug.Log("speed: " + speed);

      nextMove = Time.time + (speed * 10);
      speed += 0.2f;

      }
   }

}

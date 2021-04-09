using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomatoMovement : MonoBehaviour {

    float nextMove = 1f;
    float speed = 0.5f;
    Vector2 target;
    Vector2 startPosition;
    float movement = 0f;
    float distance = 0f;
    float movementDistance = 0.25f;
    public Sprite tomatoSplat;
    public static bool knockout = false;

    void Start() {
      GameObject player = GameObject.FindGameObjectWithTag("Player");
      target = new Vector2(player.transform.position.x, player.transform.position.y);
      startPosition = new Vector2(transform.position.x, transform.position.y);
      Debug.Log("Start x: " + startPosition.x + " Target: " + target.x);
      distance = (target.x - startPosition.x) / 0.25f;
      distance = (Mathf.Round(distance) * 0.25f) + 0.5f;

      if (distance < 1) {
        movementDistance /= 5;
      }
    }

    void Update() {

      if (Time.time > nextMove) {

        if (distance > 0 && movement != distance) {
          movement += movementDistance;
          transform.position = new Vector2((movement + startPosition.x), startPosition.y);
          transform.localScale = new Vector3(transform.localScale.x * 0.95f, transform.localScale.y * 0.95f, transform.localScale.z * 0.95f);
        }

        if (distance < 0 && movement != distance) {
          movement -= movementDistance;
          transform.position = new Vector2((movement + startPosition.x), startPosition.y);
          transform.localScale = new Vector3(transform.localScale.x * 0.95f, transform.localScale.y * 0.95f, transform.localScale.z * 0.95f);
        }

        if (movement == distance) {
          this.gameObject.GetComponent<SpriteRenderer>().sprite = tomatoSplat;
          knockout = true;
        }

        Debug.Log("Movement: " + movement);
        Debug.Log("Distance: " + distance);

        nextMove = Time.time + speed;

      }
   }

}

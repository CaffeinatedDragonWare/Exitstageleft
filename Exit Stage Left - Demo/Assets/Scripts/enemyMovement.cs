using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
  
    public float speed = 1f;
    Transform LeftCurtain, RightCurtain;
    Vector3 localScale;
    Rigidbody2D rb;
    bool movingRight = false;
    public static bool PlayerPushed = false;
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
      
        // during game over all enemies move right
        if (Gameover.GameOver == true && enemiesSpawn.birthplace > 0 && directionSet == false) {
          movingRight = true;
          directionSet = true;
        }
      
        // during game over all enemies move left
        else if (Gameover.GameOver == true && enemiesSpawn.birthplace < 0 && directionSet == false) {
          movingRight = false;
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
        if (enemiesSpawn.birthplace == RightCurtain.position.x && transform.position.x <     LeftCurtain.position.x) { // move left
          Destroy(gameObject);
        }
      
        else if (enemiesSpawn.birthplace == LeftCurtain.position.x && transform.position.x >     RightCurtain.position.x) { // move right
          Destroy(gameObject);
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
  
  

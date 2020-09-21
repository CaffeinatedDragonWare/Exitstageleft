using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
  
    public float speed = 2f;
    Transform LeftCurtain, RightCurtain;
    Vector3 localScale;
    Rigidbody2D rb;
    bool movingRight = true;
    public static bool PlayerPushed = false;
    bool PlayerPushedRight = false;
  
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D> ();
        //Player = GameObject.FindGameObjectsWithTag("Player").GetComponent<Transform> ();
        LeftCurtain = GameObject.Find("LeftCurtain").GetComponent<Transform> ();
        RightCurtain = GameObject.Find("RightCurtain").GetComponent<Transform> ();
    }

    // Update is called once per frame
    void Update() {
      
        if (transform.position.x > RightCurtain.position.x) { // move left
          movingRight = false;
        }
        
        if (transform.position.x < LeftCurtain.position.x) { // move right
          movingRight = true;
        }
      
        if (movingRight) {
          moveRight();
        }
      
        else {
          moveLeft();
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
  
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") {
          
            Physics2D.IgnoreLayerCollision(8, 8, false);
            
            if (movingRight == true && PlayerPushed == false){
              PlayerPushedRight = true;
            }
          
            PlayerPushed = true;
          }
          
        if (collision.gameObject.tag != "Player" && PlayerPushed == true) {
          Physics2D.IgnoreLayerCollision(8, 8, true);
          PlayerPushed = false;
        }
      
        if (PlayerPushed == true) {
          
          if (PlayerPushedRight == true) {
            moveRight();
          }
          
          if (PlayerPushedRight == false) {
            moveLeft();
          }
          
        }
          /*if (movingRight == true) {
            moveLeft();
          }
          
          else {
            moveRight();
          }*/
          
    }
}
  
  

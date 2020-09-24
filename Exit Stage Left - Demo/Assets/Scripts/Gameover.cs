using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{

    public static bool GameOver = false;
  
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "enemy") {
        
          Debug.Log("Gameover and stuff");
          GameOver = true;
          
          
            //Physics2D.IgnoreLayerCollision(8, 8, false);
            
//            if (movingRight == true && PlayerPushed == false){
//              PlayerPushedRight = true;
//            }
//          
//            PlayerPushed = true;
          }
          
//        if (collision.gameObject.tag != "Player" && PlayerPushed == true) {
//          Physics2D.IgnoreLayerCollision(8, 8, true);
//          PlayerPushed = false;
//        }
//      
//        if (PlayerPushed == true) {
//          
//          if (PlayerPushedRight == true) {
//            moveRight();
//          }
//          
//          if (PlayerPushedRight == false) {
//            moveLeft();
//          }
//          
//        }

          /*if (movingRight == true) {
            moveLeft();
          }
          
          else {
            moveRight();
          }*/
          
    }
}

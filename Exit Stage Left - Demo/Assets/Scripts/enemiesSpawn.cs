using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesSpawn : MonoBehaviour {
  
    // enemies
    public GameObject lady01;
    public GameObject dude01;
  
    Vector2 whereToSpawn;
    public float spawnRate = 1f;
    float nextSpawn = 0.0f;
    float x = 4f; // x value
    float y = 0.09f; // y value
    int random = 0;
    int duplicateMales = 0;
    int duplicateFemales = 0;
    // public static bool walkingRight = false;

    // Update is called once per frame
    void Update() {
      
      if (Time.time > nextSpawn) {
        
        nextSpawn = Time.time + spawnRate; // controls amount of enemies spawned at a time
//        if (enemyMovement.PlayerPushed == true){
//          x = 4f;
//        }
        whereToSpawn = new Vector2 (x, y); // controls where the enemy is spawned
        random = Random.Range(0, 2);
        
        if (Gameover.GameOver == true) { // stops enemies from spawning on gameover
          random = -1;
        }
        
        else if (random == 0 ^ duplicateMales == 2) {
          Instantiate (dude01, whereToSpawn, Quaternion.identity); // spawns enemies
          duplicateMales++;
          duplicateFemales = 0;
        }
        
        else if (random == 1 ^ duplicateFemales == 2) {
          Instantiate (lady01, whereToSpawn, Quaternion.identity); // spawns enemies
          duplicateFemales++;
          duplicateMales = 0;
        }
        
        x = x * -1; // enemy spawns on oppose side each time
        
      }
    }
}

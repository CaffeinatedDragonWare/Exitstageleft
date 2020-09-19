using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesSpawn : MonoBehaviour {
  
    // enemies
    public GameObject lady01;
    public GameObject dude01;
  
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    float x = 2f; // x value
    float y = 0.09f; // y value
    int random = 0;
    public static bool walkRight = false;
    public static bool walkLeft = false;
  
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
      
      if (Time.time > nextSpawn) {
        
        x = x * -1; // enemy spawned on oppose side each time
        if (x > 1) {
          walkRight = false;
          walkLeft = true;
        }
        
        else if (x < 1) {
          walkRight = true;
          walkLeft = false;
        }
        
        nextSpawn = Time.time + spawnRate; // controls amount of enemies spawned at a time
        whereToSpawn = new Vector2 (x, y); // controls where the enemy is spawned
        
        if (random == 0) {
          Instantiate (dude01, whereToSpawn, Quaternion.identity); // spawns enemies
          random = 1;
        }
        
        else if (random == 1) {
          Instantiate (lady01, whereToSpawn, Quaternion.identity); // spawns enemies
          random = 0;
        }
        
      }
    }
}

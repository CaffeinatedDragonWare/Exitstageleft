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
    float x = 4.2f; // x value
    float y = 0.09f; // y value
    int random = 0;
    int duplicateMales = 0;
    int duplicateFemales = 0;
    public static List<float> birthplace = new List<float>();
    public static int enemiesSpawned = 0;
    bool ready = false;
    int Spawnlimit = 3;
    // public static bool walkingRight = false;

    // Update is called once per frame
    void Update() {

      if (ready == false && ropeLift.GameStarted == false) {
        StartCoroutine(delay());
      }

      if (Time.time > nextSpawn && ready == true && Gameover.GameOver == false && enemiesSpawned <= Spawnlimit) {

        nextSpawn = Time.time + spawnRate; // controls amount of enemies spawned at a time
//        if (enemyMovement.PlayerPushed == true){
//          x = 4f;
//        }
        whereToSpawn = new Vector2 (x, y); // controls where the enemy is spawned
        random = Random.Range(0, 1);

        if (Gameover.GameOver == true) { // stops enemies from spawning on gameover
          random = -1;
        }

        // else if (Movement.gameStarted == false) {
        //   random = -1;
        // }

        if ((random == 0 && duplicateMales < 2) ^ duplicateFemales == 2) { // spawns a male
          Instantiate (dude01, whereToSpawn, Quaternion.identity); // spawns enemies
          duplicateMales++;
          duplicateFemales = 0;
          birthplace.Add(x);
          enemiesSpawned += 1;
        }

        else if ((random == 1 && duplicateFemales < 2) ^ duplicateMales == 2) { // spawns a female
          Instantiate (lady01, whereToSpawn, Quaternion.identity); // spawns enemies
          duplicateFemales++;
          duplicateMales = 0;
          birthplace.Add(x);
          enemiesSpawned += 1;
        }

        x = x * -1; // enemy spawns on oppose side each time

      }

      if (Gameover.GameOver == true) {
        ready = false;
      }

    }

    IEnumerator delay() {
        yield return new WaitForSeconds(2);
        ready = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    // characters
    public GameObject Female001;
    public GameObject Male001;
    Vector2 spawnPoint;
    Rigidbody2D rb;
    float x = 4.1f; // x value
    float y = 0.09f; // y value
    bool spawned = false;
    // bool gravityAdjusted = false;

    void Start() {
      rb = GetComponent<Rigidbody2D> ();
    }

    void Update() {

      spawnPoint = new Vector2 (0, 6); // controls where the player is spawned

      if (CharSelect.selection == 0 && spawned == false) { // && Movement.gameStarted == true
        Instantiate (Male001, spawnPoint , Quaternion.identity);
        spawned = true;
      }

      else if (CharSelect.selection == 1 && spawned == false) { // && Movement.gameStarted == true
        Instantiate (Female001, spawnPoint , Quaternion.identity);
        spawned = true;
      }

   }

}

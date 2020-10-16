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
    float y = 6f; // y value
    bool spawned = false;
    // bool gravityAdjusted = false;

    void Start() {
      rb = GetComponent<Rigidbody2D> ();
    }

    void Update() {

      spawnPoint = new Vector2 (spotLightSelect.x, y); // controls where the player is spawned

      if (CharSelect.selection == "Male" && spawned == false && spotLightSelect.selection == true) { // && Movement.gameStarted == true
        Instantiate (Male001, spawnPoint , Quaternion.identity);
        spawned = true;
      }

      else if (CharSelect.selection == "Female" && spawned == false && spotLightSelect.selection == true) { // && Movement.gameStarted == true
        Instantiate (Female001, spawnPoint , Quaternion.identity);
        spawned = true;
      }

   }

}

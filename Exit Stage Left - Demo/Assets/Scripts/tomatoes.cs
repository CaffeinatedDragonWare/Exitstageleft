using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomatoes : MonoBehaviour {
  // enemies
  public GameObject audiencehand1;
  // public GameObject audiencehand2;

  Vector2 whereToSpawn;
  public float spawnRate = 6f;
  float nextSpawn = 1f;
  int x = 0; // x value
  float y = -1; // y value
  int random = 0;
  float lastX = -13f;
  bool spawned = false;

  // Update is called once per frame
  void Update() {

    if (spawned == false) {

      nextSpawn = Time.time + spawnRate; // controls amount of enemies spawned at a time

      lastX = x;

      while (lastX == x) {
        x = Random.Range(-2, 2);
      }

      whereToSpawn = new Vector2 (x, y); // controls where the tomato is spawned
      Instantiate (audiencehand1, whereToSpawn, Quaternion.identity); // spawns tomato

      spawned = true;

    }

  }

}

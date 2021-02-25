using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingProps : MonoBehaviour {

  // enemies
  public GameObject obj003prop1moon;
  public GameObject shadow;

  Vector2 whereToSpawn;
  public float spawnRate = 2f;
  float nextSpawn = 0.0f;
  float x = 0f; // x value
  float fallingY = 8f; // y value
  float shadowY = -3.62f;
  public static List<float> birthplace = new List<float>();
  float lastX = 0f;
  // public static bool walkingRight = false;

  // Update is called once per frame
  void Update() {

    if (Time.time > nextSpawn) {

      lastX = x;

      while (lastX == x) {
        x = Random.Range(-5, 6);
      }

      nextSpawn = Time.time + spawnRate; // controls amount of enemies spawned at a time
      whereToSpawn = new Vector2 (x, shadowY); // controls where the prop's shadow is spawned
      Instantiate (shadow, whereToSpawn, Quaternion.identity); // spawns the shadow
      whereToSpawn = new Vector2 (x, fallingY); // controls where the prop is spawned
      Instantiate (obj003prop1moon, whereToSpawn, Quaternion.identity); // spawns the prop
    }
  }
}

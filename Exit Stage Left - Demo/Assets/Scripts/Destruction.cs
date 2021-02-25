using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {

    // void Update() {
    //   if (transform.position.y < -6f) {
    //     Destroy(gameObject);
    //   }
    // }

    void OnCollisionEnter2D(Collision2D collision) {
      Destroy(gameObject);
    }
}

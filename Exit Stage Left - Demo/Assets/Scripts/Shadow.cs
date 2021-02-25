using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D collision) {
      Destroy(gameObject);
    }
}

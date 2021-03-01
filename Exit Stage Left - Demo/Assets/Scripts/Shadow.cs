using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {

    float updatePosition = 8f;

    void Start() {
      transform.localScale = new Vector3(transform.localScale.x * 0.4f, transform.localScale.y * 0.4f, transform.localScale.z * 0.4f);
    }

    // Update is called once per frame
    void Update() {
      GameObject fallingProp = GameObject.FindGameObjectWithTag("fallingProp");
      transform.position = new Vector2(fallingProp.transform.position.x, -3.62f);

      if (fallingProp.transform.position.y <= updatePosition) {
        transform.localScale = new Vector3(transform.localScale.x * 1.04f, transform.localScale.y * 1.04f, transform.localScale.z * 1.04f);
        updatePosition -= 0.5f;
      }
    }

    void OnCollisionEnter2D(Collision2D collision) {
      Destroy(gameObject);
    }
}

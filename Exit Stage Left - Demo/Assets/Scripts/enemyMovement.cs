using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {
  
    public float speed;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
    
        if (enemiesSpawn.walkLeft == true) { // move left
          transform.Translate(2 * Time.deltaTime * speed , 0f, 0f);
          transform.localScale = new Vector2 (2,2);
        }
        
        else if (enemiesSpawn.walkRight == true) { // move right
          transform.Translate(-2 * Time.deltaTime * speed , 0f, 0f);
          transform.localScale = new Vector2 (-2,2);
        }
    }
}

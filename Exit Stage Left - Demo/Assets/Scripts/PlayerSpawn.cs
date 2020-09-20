using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    // characters
    public GameObject Female001;
    public GameObject Male001;
    Vector2 spawnPoint;
    bool spawned = false;
    
    // Start is called before the first frame update
    void Update() {
    
      if (CharSelect.selection == 0 && spawned == false) {
        Instantiate (Male001, spawnPoint , Quaternion.identity);
        spawned = true;
      }
        
      else if (CharSelect.selection == 1 && spawned == false) {
        Instantiate (Female001, spawnPoint , Quaternion.identity);
        spawned = true;
      }
    }

}

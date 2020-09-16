using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour {
    
    public static int selection = 3;
    bool buttonPressed1 = true;
    bool buttonPressed2 = false;
    
    // Start is called before the first frame update
    void Start() {
      
    }

    // Update is called once per frame
    void Update() {
      if (buttonPressed1 == true){ // selects female character
        selection = 1;
      }
      
      else if (buttonPressed2 == true){ // selects male character
        selection = 0;
      }
      
      else {
        
      }
      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Male001 : MonoBehaviour {

    public Renderer visible;
    
    // Start is called before the first frame update
    void Update() {
      
      if (CharSelect.selection == 0) {
        visible = GetComponent<Renderer>();
        visible.enabled = true;
        GetComponent<BoxCollider2D> ().enabled = true;
      }
      
      else {
        visible = GetComponent<Renderer>();
        visible.enabled = false;
      }
      
    }

}

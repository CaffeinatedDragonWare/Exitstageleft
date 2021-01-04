using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propWarning : MonoBehaviour {

    public GameObject env007stageHand;
    public SpriteRenderer StageHand;
    // public Renderer visible;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

      if (pendulum.command == "left") {
        transform.position = new Vector2(6.45f, transform.position.y);
        StageHand.flipX = true;
      }

      else if (pendulum.command == "right"){
        transform.position = new Vector2(-6.14f, transform.position.y);
        StageHand.flipX = false;
      }

      if (pendulum.StageHandHidden == true) {
        StageHand.enabled = false;
        pendulum.delay = 0;
      }

      else if (pendulum.StageHandHidden == false) {
        StageHand.enabled = true;
      }


   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection : MonoBehaviour
{
    // Start is called before the first frame update
    public void propDirection(string recordedCommand) {

      pendulum.command = recordedCommand;
      
    }
}

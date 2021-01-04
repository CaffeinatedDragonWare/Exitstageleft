using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selection : MonoBehaviour
{

    public void propDirection(string recordedCommand) {
        pendulum.command = recordedCommand;
    }
}

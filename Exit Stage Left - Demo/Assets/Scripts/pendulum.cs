using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulum : MonoBehaviour {

  public static string command = "nothing";
  public bool moving = false;
  public string lastCommand;
  int resetAngle = 0;
  public string inputLock = "null";
  public string status = "none";
  public int leftRotations = 0;
  public int rightRotations = 0;

  void Update() {
    Debug.Log("The current prop angle is: " + GetComponent<HingeJoint2D>().jointAngle + "degrees");
    Debug.Log("rightRotations: " + rightRotations + " leftRotations: " + leftRotations + " resetAngleLeft: " + resetAngle);

    if (command == "left") {

      var hinge = GetComponent<HingeJoint2D>();
      var motor = hinge.motor;

      if (inputLock != "left") {
        inputLock = "left";
        leftRotations += 1;
        resetAngle = 180 + (360 * leftRotations) - (360 * rightRotations);
      }

      if (hinge.jointAngle <= resetAngle) {
        motor.motorSpeed = 100;
        hinge.motor = motor;
        moving = true;
      }

      if (hinge.jointAngle >= resetAngle) {

        if (hinge.jointAngle >= resetAngle) {
          motor.motorSpeed = -10;
          hinge.motor = motor;
        }

        if (hinge.jointAngle <= resetAngle) {
          motor.motorSpeed = 0;
          hinge.motor = motor;
        }

      }
    }

    else if (command == "right") {

      var hinge = GetComponent<HingeJoint2D>();
      var motor = hinge.motor;

      if (inputLock != "right") {
        inputLock = "right";
        rightRotations += 1;
        resetAngle = 180 + (360 * leftRotations) - (360 * rightRotations);
      }

      if (hinge.jointAngle >= resetAngle) { // still moving or ready to move
        motor.motorSpeed = -100;
        hinge.motor = motor;
        moving = true;
      }

      if (hinge.jointAngle <= resetAngle) { // reached the reset position

        if (hinge.jointAngle <= resetAngle) { // counters drift by returning to correct position
          motor.motorSpeed = 10;
          hinge.motor = motor;
        }

        else if (hinge.jointAngle >= resetAngle) { // stops when in correct position
          motor.motorSpeed = 0;
          hinge.motor = motor;
        }
      }
    }

    else if (command == "stop") {
      var hinge = GetComponent<HingeJoint2D>();
      var motor = hinge.motor;
      motor.motorSpeed = 0;
      hinge.motor = motor;
      moving = false;
    }

    else if (command == "clear" && inputLock != "clear") {
        inputLock = "clear";
      }

  }
}

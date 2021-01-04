using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulum : MonoBehaviour {

  public static string command = "nothing";
  public string lastCommand;
  int resetAngle = 0;
  public string inputLock = "null";
  public string status = "none";
  public int leftRotations = 0;
  public int rightRotations = 0;
  public static float propWarningDelay = 0;
  public static int delay = 2;
  public static bool StageHandHidden = true;

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
        StageHandHidden = false;
      }

      propWarningDelay += Time.deltaTime;
      Debug.Log("Warning! Prop will swing in from the left side!");

      if (hinge.jointAngle <= resetAngle && propWarningDelay > delay) {
        motor.motorSpeed = 100;
        hinge.motor = motor;
      }

      if (resetAngle - 270 <= GetComponent<HingeJoint2D>().jointAngle) {
        StageHandHidden = true;
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
        StageHandHidden = false;
      }

      propWarningDelay += Time.deltaTime;
      Debug.Log("Warning! Prop will swing in from the right side!");

      if (hinge.jointAngle >= resetAngle && propWarningDelay > delay) { // still moving or ready to move
        motor.motorSpeed = -100;
        hinge.motor = motor;
      }

      if (resetAngle + 270 >= GetComponent<HingeJoint2D>().jointAngle) {
        StageHandHidden = true;
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
    }

    else if (command == "clear" && inputLock != "clear") {
        inputLock = "clear";
    }

  }
}

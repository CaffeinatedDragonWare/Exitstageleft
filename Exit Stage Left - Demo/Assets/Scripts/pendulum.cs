using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulum : MonoBehaviour {

  public static string command = "nothing";
  public bool moving = false;
  public string lastCommand;
  public int resetAngleRight = -180;
  public int resetAngleLeft = 540;
  public bool leftChanged = false;
  public bool rightChanged = false;
  public bool leftIsReset = false;
  public bool rightIsReset = false;
  public string status = "none";

  void Start() {
      var hinge = GetComponent<HingeJoint2D>();
      var motor = hinge.motor;
      hinge.useMotor = false;
      motor.motorSpeed = 0;
      motor.maxMotorTorque = 10000;
      hinge.useLimits = false;
      hinge.motor = motor;

  }

  void Update() {
    Debug.Log("The current prop angle is: " + GetComponent<HingeJoint2D>().jointAngle + "degrees");
    Debug.Log(status);

    // if (moving == true && GetComponent<HingeJoint2D>().jointAngle >= 540 || GetComponent<HingeJoint2D>().jointAngle <= -180) {
    //   var hinge = GetComponent<HingeJoint2D>();
    //   var motor = hinge.motor;
    //   motor.motorSpeed = 0;
    //   hinge.motor = motor;
    //   moving = false;
    //   lastCommand = command;
    // }

    if (command == "left") { // figure out how swing the prop left or right twice in a row rather than toggle

      var hinge = GetComponent<HingeJoint2D>();
      var motor = hinge.motor;

      if (hinge.jointAngle <= resetAngleLeft) {
        motor.motorSpeed = 100;
        hinge.motor = motor;
        moving = true;
      }

      if (hinge.jointAngle >= resetAngleLeft) {

        if (leftIsReset == true) {
          if (hinge.jointAngle >= resetAngleLeft) {
            motor.motorSpeed = -10;
            hinge.motor = motor;
          }

          if (hinge.jointAngle <= resetAngleLeft) {
            motor.motorSpeed = 0;
            hinge.motor = motor;
          }
        }

        else if (leftChanged == true) {
          leftChanged = false;
          resetAngleLeft = 540;
          status = "Command: Stopped + Updated";
          leftIsReset = true;
          rightIsReset = false;
        }

        else if (leftChanged == false) {
          resetAngleRight = 180;
          leftChanged = true;
          status = "Command: Stopped";
          leftIsReset = true;
          rightIsReset = false;
        }
      }
    }

    else if (command == "right") {

      var hinge = GetComponent<HingeJoint2D>();
      var motor = hinge.motor;

      if (hinge.jointAngle >= resetAngleRight) {
        motor.motorSpeed = -100;
        hinge.motor = motor;
        moving = true;
      }

      if (hinge.jointAngle <= resetAngleRight) {

        if (rightIsReset == true) {
          if (hinge.jointAngle <= resetAngleRight) {
            motor.motorSpeed = 10;
            hinge.motor = motor;
          }

          else if (hinge.jointAngle >= resetAngleRight) {
            motor.motorSpeed = 0;
            hinge.motor = motor;
          }
        }

        else if (rightChanged == true) {
          rightChanged = false;
          resetAngleRight = -180;
          status = "Command: Updated";
          rightIsReset = true;
          leftIsReset = false;
        }

        else if (rightChanged == false) {
          resetAngleRight = 180;
          rightChanged = true;
          status = "Command: Stopped";
          rightIsReset = true;
          leftIsReset = false;
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

    else if (command == "clear") {
      rightIsReset = false;
      leftIsReset = false;
    }

    // else if (command == "reset") {
    //   // transform.Rotate (0,0,-180f,Space.Self);
    //   var hinge = GetComponent<HingeJoint2D>();
    //
    // }

    // else if (command == "reset") {
    //   hinge.motor = motor;
    // }

  }
}

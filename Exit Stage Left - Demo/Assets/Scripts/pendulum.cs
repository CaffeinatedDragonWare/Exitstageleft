using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulum : MonoBehaviour {

  public static string command = "nothing";

  void Start() {
      var hinge = GetComponent<HingeJoint2D>();
      var motor = hinge.motor;
      hinge.useMotor = true;
      motor.motorSpeed = 0;
      motor.maxMotorTorque = 10000;
      hinge.useLimits = false;
      hinge.motor = motor;
  }

  void Update() {

    if (command == "left") {
      var hinge = GetComponent<HingeJoint2D>();
      var motor = hinge.motor;
      motor.motorSpeed = 100;
      hinge.motor = motor;
    }

    else if (command == "right") {
      var hinge = GetComponent<HingeJoint2D>();
      var motor = hinge.motor;
      motor.motorSpeed = -100;
      hinge.motor = motor;
    }

    else if (command == "stop") {
      var hinge = GetComponent<HingeJoint2D>();
      var motor = hinge.motor;
      motor.motorSpeed = 0;
      hinge.motor = motor;
    }

    // else if (command == "reset") {
    //   hinge.motor = motor;
    // }

  }
}

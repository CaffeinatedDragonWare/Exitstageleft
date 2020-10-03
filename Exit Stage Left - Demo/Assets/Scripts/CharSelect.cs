using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour {

    public static string selection = "nothing";

    // Update is called once per frame
    public void CharacterSelection(string CharacterSelected) {

      selection = CharacterSelected;
      // if (input == "Female"){ // selects female character
      //   selection = 1;
      // }
      //
      // else if (input == "Male"){ // selects male character
      //   selection = 0;
      // }
      //
      // else {
      //
      // }

    }
}

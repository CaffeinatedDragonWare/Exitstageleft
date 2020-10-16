using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    // Start is called before the first frame update
    public void ChangeToScene(string sceneToLoad) {

      if (CharSelect.selection == "nothing") {

      }

      else if (CharSelect.selection != "nothing") {
        SceneManager.LoadScene(sceneToLoad);
      }

      else if (Gameover.GameOver == true) {
        SceneManager.LoadScene(sceneToLoad);
        //Gameover.GameOver = false;
      }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Vector2 startTouchPosition, endTouchPosition;
    private Rigidbody2D rb;
    private float jumpForce = 300f;
    bool facingRight = false;
    bool facingLeft = false;
    int frameCounter = 0;
    bool ducking = false;
    int duckingFrames = 150; // change to 30 when building and 150 when live testing
    public static bool gameStarted = false;

    // sprites
    public Sprite bow0;
    public Sprite bow1;
    public Sprite defL;
    public Sprite defR;
    public Sprite frenchL;
    public Sprite frenchR;
    public Sprite dabL;
    public Sprite dabR;
    public Sprite rockL;
    public Sprite rockR;
    public Sprite jazzL;
    public Sprite jazzR;
    public Sprite jumpL;
    public Sprite jumpR;
    public Sprite duckL;
    public Sprite duckR;

    int newRandomPose = 0;
    int oldRandomPose = 0;
    bool justSpawned = true;

    private void Start() {
      rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {

//      Debug.Log("startTouchPosition: " + startTouchPosition);
//      Debug.Log("endTouchPosition: " + endTouchPosition);

      // return to original pose once on ground
      // velocity is used to calculate when character is on the ground

      GameObject player = GameObject.FindGameObjectWithTag("Player");

      if (player.transform.position.y < 0.016 && justSpawned == true) {
        PoseForward();
        justSpawned = false;
      }

      if (rb.velocity.y < -7 && facingRight == true) {
        PoseRight();
      }

      else if (rb.velocity.y < -7 && facingLeft == true) {
        PoseLeft();
      }

      else if (rb.velocity.y < -7 && facingLeft == false && facingRight == false) {

      }

      // return to original pose after ducking
      // frame counter is used to delay ducking animation
      if (frameCounter == duckingFrames && ducking == true && facingRight == true) {
        PoseRight();
        ducking = false;
      }

      else if (frameCounter == duckingFrames && ducking == true && facingLeft == true) {
        PoseLeft();
        ducking = false;
      }

      else if (frameCounter == duckingFrames && ducking == true && facingLeft == false && facingRight == false) {
        PoseForward();
        ducking = false;
      }

      if (Gameover.GameOver == true) { // stop character from moving on gameover

      }

      // Uses TouchScreen input to move character right or left
      else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
		startTouchPosition = Input.GetTouch(0).position;
      }

      else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
		endTouchPosition = Input.GetTouch(0).position;
        gameStarted = true;

            // Jump
            if (endTouchPosition.y > (startTouchPosition.y + 80) && transform.position.y < 0.2f) {

              // jump left
              if (facingLeft) {
                JumpLeft();
              }

              // jump right
              else if (facingRight) {
                JumpRight();
              }

              // jump forward
              else {
                JumpForward();
              }
            }

            // Duck
            if ((endTouchPosition.y + 80) < startTouchPosition.y && transform.position.y < 1f) {

              // duck right
              if (facingRight == true) {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = duckR;
                frameCounter = 0;
                ducking = true;
              }

              // duck left
              else if (facingLeft == true) {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = duckL;
                frameCounter = 0;
                ducking = true;
              }

              // duck forward
              else if (facingLeft == false && facingRight == false) {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = bow1;
                frameCounter = 0;
                ducking = true;
              }
            }

            // Move Left
			if ((endTouchPosition.x + 5) < startTouchPosition.x && transform.position.x > -2.4f && endTouchPosition.y < (startTouchPosition.y + 80) && (endTouchPosition.y + 70) > startTouchPosition.y) {

              // Move if not in the air
              if (transform.position.y < 1f) {
                transform.position = new Vector2(transform.position.x - 1.25f, transform.position.y);
                facingRight = false;
                facingLeft = true; // facing left
                oldRandomPose = newRandomPose;

                while (oldRandomPose == newRandomPose) { // ensures each pose is unique
                  newRandomPose = Random.Range(1, 5); // picks random pose
                }

                PoseLeft();
              }

            }


            // Move Right
			if (endTouchPosition.x > (startTouchPosition.x + 5) && transform.position.x < 2.4f && endTouchPosition.y < (startTouchPosition.y + 80) && (endTouchPosition.y + 70) > startTouchPosition.y) {

              // Move if not in the air
              if (transform.position.y < 1f) {
                transform.position = new Vector2(transform.position.x + 1.25f, transform.position.y);
                facingRight = true; // facing right
                facingLeft = false;
                oldRandomPose = newRandomPose;

                while (oldRandomPose == newRandomPose) { // ensures each pose is unique
                  newRandomPose = Random.Range(1, 5); // picks random pose
                }

                PoseRight();

              }

            }

		}
        frameCounter++; // counts frames
      }

      // poses character right
      public void PoseRight() {

        switch(newRandomPose) { // implements selected pose
              case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = defR;
                break;
              case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = frenchR;
                break;
              case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = dabR;
                break;
              case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = rockR;
                break;
              case 5:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = jazzR;
                break;
              default:
                break;
              }
      }

      // poses character left
      public void PoseLeft() {

        switch(newRandomPose) { // implements selected pose
              case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = defL;
                break;
              case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = frenchL;
                break;
              case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = dabL;
                break;
              case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = rockL;
                break;
              case 5:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = jazzL;
                break;
              default:
                break;
              }
      }

      // poses character forward
      public void PoseForward() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = bow0;
      }

      // makes character jump left
      public void JumpLeft() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = jumpL;
        rb.AddForce (Vector2.up * jumpForce);
      }

      // makes character jump right
      public void JumpRight() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = jumpR;
        rb.AddForce (Vector2.up * jumpForce);
      }

      // makes character jump forward
      public void JumpForward() {
        rb.AddForce (Vector2.up * jumpForce);
      }


}

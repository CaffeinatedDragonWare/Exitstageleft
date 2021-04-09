using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Vector2 startTouchPosition, endTouchPosition;
    private Rigidbody2D rb;
    public BoxCollider2D HitBox;
    private float jumpForce = 300f;
    bool facingRight = false;
    bool facingLeft = false;
    int frameCounter = 0;
    bool ducking = false;
    bool Grounded = false;
    public Vector2 HitBoxSize;
    public Vector2 HitBoxOffset;

    int duckingFrames = 150; // change to 30 when building and 150 when live testing
    // public static bool gameStarted = false;

    // sprites
    public Sprite bow0;
    public Sprite bow1;
    public Sprite defL;
    public Sprite defR;
    public Sprite duckL;
    public Sprite duckR;
    public Sprite duckBackL;
    public Sprite duckBackR;
    public Sprite duckBellyL;
    public Sprite duckBellyR;
    public Sprite duckBack2L;
    public Sprite duckBack2R;
    public Sprite dabL;
    public Sprite dabR;
    public Sprite rockL;
    public Sprite rockR;
    public Sprite jazzL;
    public Sprite jazzR;
    public Sprite jump1L;
    public Sprite jump2L;
    public Sprite jump3L;
    public Sprite jump4L;
    // public Animation anim;
    public Sprite jump1R;
    public Sprite jump2R;
    public Sprite jump3R;
    public Sprite jump4R;
    public Sprite knockOut;

    int newRandomPose = 0;
    int oldRandomPose = 0;
    bool justSpawned = true;
    bool jumped = false;
    float timeInterval = 0;
    float X = 0.124f;
    float DuckingY = 0.5f;
    float NormalY = 1.22f;
    float NormalOffsetY;
    float DuckingOffsetY;
    float OffsetX;
    int oldDuckingPose = 0;
    int newDuckingPose = 0;
    int oldJumpingPose = 0;
    int newJumpingPose = 0;
    [SerializeField] public LayerMask stageLayerMask;
    public BoxCollider2D boxCollider2d;

    private void Start() {
      rb = GetComponent<Rigidbody2D>();
      HitBox = GetComponent<BoxCollider2D>();

      if (CharSelect.selection == "Male") {
        OffsetX = 0.113f;
        DuckingOffsetY = -0.4f;
        NormalOffsetY = 0f;
      }

      else if (CharSelect.selection == "Female") {
        OffsetX = 0.135f;
        DuckingOffsetY = -0.35f;
        NormalOffsetY = -0.05f;
      }
      //anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    private void Update() {

//      Debug.Log("startTouchPosition: " + startTouchPosition);
//      Debug.Log("endTouchPosition: " + endTouchPosition);

      // return to original pose once on ground
      // velocity is used to calculate when character is on the ground

      GameObject player = GameObject.FindGameObjectWithTag("Player");

      // Debug.Log("raycast: " + Grounded);

      if (Grounded == false) {
        jumped = true;
      }

      else if (Grounded == true && justSpawned == true) {
        PoseForward();
        justSpawned = false;
      }

      else if (Grounded == true && facingRight == true && jumped == true) {
        PoseRight();
        jumped = false;
      }

      else if (Grounded == true && facingLeft == true && jumped == true) {
        PoseLeft();
        jumped = false;
      }

      else if (Grounded == true && facingLeft == false && facingRight == false && jumped == true) {
        jumped = false;
      }

      Grounded = IsGrounded();

      if (tomatoMovement.knockout == true) {
        knockedOut();
      }

      // return to original pose after ducking
      // frame counter is used to delay ducking animation
      if (frameCounter == duckingFrames && ducking == true) {

        if (facingRight == true) {
          PoseRight();
          ducking = false;

        }

        else if (facingLeft == true) {
          PoseLeft();
          ducking = false;
        }

        else if (facingLeft == false && facingRight == false) {
          PoseForward();
          ducking = false;
        }

        HitBoxSize = new Vector2(X, NormalY);
        HitBoxOffset = new Vector2(OffsetX, NormalOffsetY);
        HitBox.size = HitBoxSize;
        HitBox.offset = HitBoxOffset;

      }

      if (Gameover.GameOver == true) { // stop character from moving on gameover

      }

      // Uses TouchScreen input to move character right or left
      else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
		startTouchPosition = Input.GetTouch(0).position;
      }

      else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
		endTouchPosition = Input.GetTouch(0).position;
        // gameStarted = true;

            // Jump
            if (endTouchPosition.y > (startTouchPosition.y + 90) && transform.position.y < 0.2f) {

              // jump left
              if (facingLeft == true) {

                oldJumpingPose = newJumpingPose;

                while (oldJumpingPose == newJumpingPose) { // ensures each pose is unique
                  newJumpingPose = Random.Range(1, 4); // picks random pose
                }

                JumpLeft();
              }

              // jump right
              else if (facingRight == true) {

                oldJumpingPose = newJumpingPose;

                while (oldJumpingPose == newJumpingPose) { // ensures each pose is unique
                  newJumpingPose = Random.Range(1, 4); // picks random pose
                }

                JumpRight();
              }

              // jump forward
              else {
                JumpForward();
              }
            }

            // Duck
            if ((endTouchPosition.y + 90) < startTouchPosition.y && transform.position.y < 1f) {

              // duck right
              if (facingRight == true) {

                oldDuckingPose = newDuckingPose;

                while (oldDuckingPose == newDuckingPose) { // ensures each pose is unique
                  newDuckingPose = Random.Range(1, 4); // picks random pose
                }

                DuckRight();
                frameCounter = 0;
                ducking = true;
              }

              // duck left
              else if (facingLeft == true) {

                oldDuckingPose = newDuckingPose;

                while (oldDuckingPose == newDuckingPose) { // ensures each pose is unique
                  newDuckingPose = Random.Range(1, 4); // picks random pose
                }

                DuckLeft();
                frameCounter = 0;
                ducking = true;
              }

              // duck forward
              else if (facingLeft == false && facingRight == false) {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = bow1;
                frameCounter = 0;
                ducking = true;
              }

              HitBoxSize = new Vector2(X, DuckingY);
              HitBoxOffset = new Vector2(OffsetX, DuckingOffsetY);
              HitBox.size = HitBoxSize;
              HitBox.offset = HitBoxOffset;
            }

            // Move Left
			if ((endTouchPosition.x + 5) < startTouchPosition.x && transform.position.x > -2.4f && endTouchPosition.y < (startTouchPosition.y + 80) && (endTouchPosition.y + 70) > startTouchPosition.y) {

              // Move if not in the air
              if (transform.position.y < 1f) {
                transform.position = new Vector2(transform.position.x - 1.25f, transform.position.y);
                spotLightSelect.x -= 1.25f;
                facingRight = false;
                facingLeft = true; // facing left
                oldRandomPose = newRandomPose;

                while (oldRandomPose == newRandomPose) { // ensures each pose is unique
                  newRandomPose = Random.Range(1, 4); // picks random pose
                }

                PoseLeft();
              }

            }


            // Move Right
			if (endTouchPosition.x > (startTouchPosition.x + 5) && transform.position.x < 2.4f && endTouchPosition.y < (startTouchPosition.y + 80) && (endTouchPosition.y + 70) > startTouchPosition.y) {

              // Move if not in the air
              if (transform.position.y < 1f) {
                transform.position = new Vector2(transform.position.x + 1.25f, transform.position.y);
                spotLightSelect.x += 1.25f;
                facingRight = true; // facing right
                facingLeft = false;
                oldRandomPose = newRandomPose;

                while (oldRandomPose == newRandomPose) { // ensures each pose is unique
                  newRandomPose = Random.Range(1, 4); // picks random pose
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
                this.gameObject.GetComponent<SpriteRenderer>().sprite = dabR;
                break;
              case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = rockR;
                break;
              case 4:
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
                this.gameObject.GetComponent<SpriteRenderer>().sprite = dabL;
                break;
              case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = rockL;
                break;
              case 4:
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

        switch(newJumpingPose) { // implements selected pose
              case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = jump1L;
                break;
              case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = jump2L;
                break;
              case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = jump3L;
                break;
              case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = jump4L;
                break;
              default:
                break;
              }

        rb.AddForce (Vector2.up * jumpForce);
      }

      // makes character jump right
      public void JumpRight() {

        switch(newJumpingPose) { // implements selected pose
              case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = jump1R;
                break;
              case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = jump2R;
                break;
              case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = jump3R;
                break;
              case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = jump4R;
                break;
              default:
                break;
              }

        rb.AddForce (Vector2.up * jumpForce);
      }

      // makes character jump forward
      public void JumpForward() {
        rb.AddForce (Vector2.up * jumpForce);
      }

      public void DuckRight() {

        switch(newDuckingPose) { // implements selected pose
              case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = duckR;
                break;
              case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = duckBackR;
                break;
              case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = duckBellyR;
                break;
              case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = duckBack2R;
                break;
              default:
                break;
              }
      }

      public void DuckLeft() {

        switch(newDuckingPose) { // implements selected pose
              case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = duckL;
                break;
              case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = duckBackL;
                break;
              case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = duckBellyL;
                break;
              case 4:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = duckBack2L;
                break;
              default:
                break;
              }
      }

      public void knockedOut() {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = knockOut;
      }

      public bool IsGrounded() {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHitBox = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeight, stageLayerMask);

        if (raycastHitBox.collider == null) {
          //Debug.Log("raycast: Null");
          return false;
        }

        else {
          //Debug.Log("raycast: " + raycastHitBox.collider);
          return true;
        }

      }

}

using UnityEngine;

public class playerController : MonoBehaviour {

    public float speed;
    public float jumpForce;
    private float moveInput;
    public int score;

    private Rigidbody2D playerRb;
    private Transform playerTrans;
    public Transform camTrans;

    private bool facingRight = true;

    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public Vector3 offset;
    private int extraJump;
    public int extraJumpValue;

    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        playerTrans = GetComponent<Transform>();
        extraJump = extraJumpValue;
    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(moveInput * speed, playerRb.velocity.y);

        if(facingRight == false && moveInput > 0) {
            Flip();
        } else if(facingRight == true && moveInput < 0) {
            Flip();
        }
    }

    void Update() {
        if(isGrounded) {
            extraJump = extraJumpValue;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJump > 0) {
            playerRb.velocity = Vector2.up * jumpForce;
            extraJump--;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJump == 0 && isGrounded) {
            playerRb.velocity = Vector2.up * jumpForce;
        }

        CamFollow();

        scoreFunc();
    }

    void scoreFunc() {
        if (score < 0) {
            score = 0;
        }
    }

    void CamFollow() {
        camTrans.localPosition = new Vector3(playerTrans.position.x, 0, offset.z);

        if (camTrans.position.x > 16) {
            camTrans.localPosition = new Vector3(16, 0, -10);
        } else if (camTrans.position.x < 1) {
            camTrans.localPosition = new Vector3(1, 0, -10);
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
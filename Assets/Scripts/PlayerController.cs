using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public int extraJumpsValue;
    private float moveInput;
    

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private int extraJumps;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
        //Ignore the collisions between layer 0 (default) and layer 8 (Room) 
        Physics2D.IgnoreLayerCollision(0, 8 , true);
    }


    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        anim.SetBool("isGrounded", isGrounded);

        //for animations
        if (moveInput == 0 || isGrounded == false) {
            anim.SetBool("isWalking", false);
        } else {
            anim.SetBool("isWalking", true);
        }

        //for making character look right and lefts side
        if(moveInput > 0) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if(moveInput <0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        // JUMP + DOUBLE JUMP - start

        if(isGrounded == true){
            extraJumps = extraJumpsValue;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0) {
            isJumping = true;
            anim.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;

        }else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true) {
            isJumping = true;
            anim.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpForce;
        }
       
        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            isJumping = false;
        }

        if ( isJumping == false) {
            anim.SetBool("isJumping", false);
        }
      

        //NEW JUMP - end

        /* old one

        if (isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow)) {
            isJumping = true;
            anim.SetBool("isJumping", true);
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKey(KeyCode.UpArrow) && isJumping == true) {
            
            if(jumpTimeCounter > 0) {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else{
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) {
            isJumping = false;           
        }

        if(isGrounded == false && isJumping == false) {
            anim.SetBool("isJumping", false);
        }
        */


        // CROUCH
        if (Input.GetKeyDown(KeyCode.DownArrow ) && isGrounded == true) {
            anim.SetBool("isCrouching", true);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow ) || moveInput != 0 ) {
            anim.SetBool("isCrouching", false);
        }


    }

   
}

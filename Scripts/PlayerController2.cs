using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 10.0f;
    float walkForce = 10.0f;
    private bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {

        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

       
            float horizontalInput = Input.GetAxis("Horizontal"); //gets the keys used for the arrow keys

            Vector3 moveDirection = new Vector3(horizontalInput, 0, 0); //plugs in the value so it knows which way to move
            transform.Translate(moveDirection * walkForce * Time.deltaTime);

            //animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

            if (horizontalInput < 0) //instead of using the animations in the animator, I reversed the movements through here
            {
                animator.SetBool("isMoving", true);
                transform.localScale = new Vector3(1, 1, 1);
            }
            //move right and flips her animation
            else if (horizontalInput > 0) //if PC is facing the other way then the animation will follow
            {
                animator.SetBool("isMoving", true); //this is for swapping between moving and standing idle
                transform.localScale = new Vector3(-1, 1, 1); //flipping the x so that the animation changes
            }
            else
            {
                animator.SetBool("isMoving", false); //should go here if idle, which changes the animation
            }
       

            Jump();

       
    }


    void Jump()
    {

        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            rigid2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse); //supposed to be the jump but its not working perfectly 

        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Ground") //checks if players on the ground or not
        {

            isGrounded = true;
            //animator.SetBool("isGrounded", true);

        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.tag == "Ground") //for checking for jumping
        {

            isGrounded = false;
            //animator.SetBool("isGrounded", false);

        }
    }



}

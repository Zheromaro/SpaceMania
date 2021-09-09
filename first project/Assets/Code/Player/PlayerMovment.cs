using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed = 5;
    
    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    Vector2 animationMove;

    bool flipLeft;

    bool isMove;

    void Start()
    {
        isMove = true;
        flipLeft = true;
    }

    void Update()
    {

        if (flipLeft == true)
        {

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                movement.x = 1.4f;
            }
            else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q)))
            {
                movement.x = 0.6f;
            }
            else
            {
                movement.x = 1f;
            }
        }
        else if (flipLeft == false)
        {

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                movement.x = -0.6f;
            }
            else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q)))
            {
                movement.x = -1.4f;
            }
            else
            {
                movement.x = -1f;
            }
        }

        movement.y = Input.GetAxisRaw("Vertical");

        animationMove.x = Input.GetAxisRaw("Horizontal");
        animationMove.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", animationMove.x);
        animator.SetFloat("Vertical", animationMove.y);
        animator.SetFloat("Speed", animationMove.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.E))
        {
            isMove = true;
        }
    }

    private void FixedUpdate()
    {
        if (isMove == true)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Flip Right") && flipLeft == true)
        {
            flipLeft = false;
            animator.Play("Flip Right");  
        }

        if (collision.CompareTag("Flip Left") && flipLeft == false)
        {
            flipLeft = true;
            animator.Play("Flip Left");
        }

        if (collision.CompareTag("Stop"))
        {
            isMove = false;
        }

    }
}
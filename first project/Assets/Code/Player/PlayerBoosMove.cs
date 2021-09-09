using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoosMove : MonoBehaviour
{
    public float moveSpeed = 5;

    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    bool flipLeft;

    void Start()
    {
        flipLeft = true;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.E) && flipLeft == true)
        {
            flipLeft = false;
            animator.Play("Flip Right");

        }
        else if (Input.GetKeyDown(KeyCode.E) && flipLeft == false)
        {
            flipLeft = true;
            animator.Play("Flip Left");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

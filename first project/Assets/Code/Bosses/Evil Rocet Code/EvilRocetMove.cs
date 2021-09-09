using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilRocetMove : MonoBehaviour
{
    public float Speed = 5f;
    public Rigidbody2D rb;
    public Transform player;
    public Animator animator;

     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

     void Update()
    {
        animator.Play("EvilRocet_Run");
        Vector2 target = new Vector2(rb.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.transform.position, target, Speed * Time.deltaTime);
        rb.MovePosition(newPos);
    }
}

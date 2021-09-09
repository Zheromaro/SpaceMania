using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyFollow : MonoBehaviour
{
    public float speed;
    public float lineOfSite;

    private Transform player;

    bool startMove = true;
    GameObject target;
    Rigidbody2D rb
        ;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (startMove == true)
        {
            rb = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Player");
            Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;

            if (distanceFromPlayer < lineOfSite)
            {
                rb.velocity = new Vector2(moveDir.x, moveDir.y);
                startMove = false;
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
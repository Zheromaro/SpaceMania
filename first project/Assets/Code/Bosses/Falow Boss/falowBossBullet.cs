using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falowBossBullet : MonoBehaviour
{
    public float speed;
    public int dameg = 20;
    public Rigidbody2D rb;

    GameObject target;
    Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth health = hitInfo.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.TakeDamage(dameg);
            Destroy(gameObject);
        }
    }
}

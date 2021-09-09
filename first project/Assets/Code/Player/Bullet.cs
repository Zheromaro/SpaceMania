using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int dameg = 20;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enimy enemy = hitInfo.GetComponent<Enimy>();
        PlayerHealth health = hitInfo.GetComponent<PlayerHealth>();
        BossHealth bossHealth = hitInfo.GetComponent<BossHealth>();

        if (enemy != null)
        {
            enemy.TakeDamege(dameg);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (bossHealth != null)
        {
            bossHealth.TakeDamege(dameg);
            Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }

        if (health != null)
        {
            health.TakeDamage(dameg);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (hitInfo.CompareTag("Ground"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }


    }
}

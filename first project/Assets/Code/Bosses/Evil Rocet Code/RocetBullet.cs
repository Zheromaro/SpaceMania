using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocetBullet: MonoBehaviour
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
        PlayerHealth health = hitInfo.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.TakeDamage(dameg);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MisslesLancher : MonoBehaviour
{
    public float rotateSpeed = 200f;

    public Transform firePoint;
    public GameObject bulletPrefab;

    private Transform target;
    private Rigidbody2D rb;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;
    }

    private void OnBecameVisible()
    {
        InvokeRepeating("Shoot", 1.5f, 1.5f);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }
}

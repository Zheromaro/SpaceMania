using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingInBoos : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    Animator animator;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }

}

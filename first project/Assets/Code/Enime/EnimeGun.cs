using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimeGun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }

    private void OnBecameVisible()
    {
        InvokeRepeating("Shoot", 1.5f, 1.5f);
    }
}

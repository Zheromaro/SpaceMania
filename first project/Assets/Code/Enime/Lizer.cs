using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizer : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public int damage = 50;
    public float fireRate = 1f;

    private float nextFireTime;

    void Update()
    {
        if (nextFireTime < Time.time)
        {
            StartCoroutine(Shoot());
            nextFireTime = Time.time + fireRate;
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            PlayerHealth health = hitInfo.transform.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 50);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.5f);

        lineRenderer.enabled = false;
    }

}

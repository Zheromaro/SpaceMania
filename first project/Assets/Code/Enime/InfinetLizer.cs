using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinetLizer : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public int damage = 50;

    bool isHit;

    private void Start()
    {
        isHit = false;
    }
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            PlayerHealth health = hitInfo.transform.GetComponent<PlayerHealth>();

            if (health != null && isHit == false)
            {
                health.TakeDamage(damage);
                isHit = true;
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
    }
}

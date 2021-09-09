using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enimy4Gun : MonoBehaviour
{

    public Transform leftFirePoint;
    public Transform rightFirePoint;
    public Transform UpFirePoint;
    public Transform DawnFirePoint;

    public GameObject leftBulletPrefab;
    public GameObject rightBulletPrefab;
    public GameObject UpBulletPrefab;
    public GameObject DawnBulletPrefab;

    void Shoot()
    {
        Instantiate(leftBulletPrefab, leftFirePoint.transform.position, leftFirePoint.transform.rotation);
        Instantiate(rightBulletPrefab, rightFirePoint.transform.position, rightFirePoint.transform.rotation);
        Instantiate(UpBulletPrefab, UpFirePoint.transform.position, UpFirePoint.transform.rotation);
        Instantiate(DawnBulletPrefab, DawnFirePoint.transform.position, DawnFirePoint.transform.rotation);
    }

    private void OnBecameVisible()
    {
        InvokeRepeating("Shoot", 1, 1);
    }
}

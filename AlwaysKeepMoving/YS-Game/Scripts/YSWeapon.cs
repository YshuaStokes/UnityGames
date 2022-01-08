using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YSWeapon : MonoBehaviour
{
    
    public Transform firePoint;

    public Transform firePoint1;

    public Transform firePoint2;

    
    public GameObject bulletPrefab;

    public bool Lazer = false;
    public int damage = 7;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    public bool readyToShoot = true;
    //private float bulletSpeed = 500f;
    


    // Update is called once per frame
    void Update()
    {
        

        




        if (Input.GetButtonDown("Fire1") && !Lazer && readyToShoot)
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Lazer = true;
            
        } else if (Input.GetButtonUp("Fire2"))
        {
            Lazer=false;
        }

        if (Input.GetButtonDown("Fire1") && Lazer && readyToShoot)
        {
            Debug.Log("LAZER BEAM!");
            StartCoroutine(lazerShoot());
        }
    }
    
    IEnumerator Shoot()
    {
       

       
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);









        readyToShoot = false;
        yield return new WaitForSeconds(1f);
        readyToShoot=true;
    }

    IEnumerator lazerShoot ()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        } else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;

        readyToShoot = false;

        yield return new WaitForSeconds(1f);

        readyToShoot = true;
    }
}

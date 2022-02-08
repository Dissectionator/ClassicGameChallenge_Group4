using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponB : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("v"))
        {
            Shoot();
        }
    }

    void Shoot ()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

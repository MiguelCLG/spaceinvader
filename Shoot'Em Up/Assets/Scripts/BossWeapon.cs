using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{

    public Transform firePoint_1;
    public Transform firePoint_2;
    public Transform fireLaser;

    public GameObject bulletPrefab;
    public GameObject laserPrefab;

    private Boss boss;


    // Update is called once per frame

    private void Start()
    {
         boss = GetComponent<Boss>();
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint_1.position, bulletPrefab.transform.rotation);
        Instantiate(bulletPrefab, firePoint_2.position, bulletPrefab.transform.rotation);
    }

    public void ShootLaser()
    {
        boss.stopped = true;
        GameObject laser = Instantiate(laserPrefab, fireLaser.position, laserPrefab.transform.rotation);
        laser.transform.parent = transform;
    }
}

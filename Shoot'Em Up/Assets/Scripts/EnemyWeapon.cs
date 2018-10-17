using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public Transform firePoint_1;
    public Transform firePoint_2;
    public GameObject bulletPrefab;


    // Update is called once per frame
   
   public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint_1.position, bulletPrefab.transform.rotation);
        Instantiate(bulletPrefab, firePoint_2.position, bulletPrefab.transform.rotation);
    }
}

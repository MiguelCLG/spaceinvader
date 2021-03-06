﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    public HUD hud;

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1") && hud.spawning == 0 && !PauseMenu.isPaused)
        {
            Shoot();
        }
	}

    void Shoot() {
        FindObjectOfType<AudioManager>().Play("LaserShot");
        Instantiate(bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);
    }
}

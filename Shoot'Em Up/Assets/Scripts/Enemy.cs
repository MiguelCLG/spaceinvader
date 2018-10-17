using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 100f;

    public EnemyWeapon enemyWeapon;
  
    public float shootingRate = 2f;

    private float shootCooldown;

    void Start()
    {
        
        shootCooldown = Random.Range(0f, 2f);
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        else {
            Attack();
        }
    }

    public void Attack()
    {
        if (CanAttack)
        {
            shootingRate = Random.Range(0f, 2f);
            shootCooldown = shootingRate;
            enemyWeapon.Shoot();
  
        }
    }

    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }

public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

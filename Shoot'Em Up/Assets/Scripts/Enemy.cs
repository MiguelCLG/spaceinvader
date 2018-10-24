using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health = 3;

    public EnemyWeapon enemyWeapon;
    private HUD hud;



    public float shootingRate = 2f;
    private float shootCooldown;

    void Start()
    {
        hud = FindObjectOfType<HUD>();
        shootCooldown = Random.Range(2f, 6f);
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
            shootingRate = Random.Range(2f, 6f);
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
        LootSystem lootSystem = FindObjectOfType<LootSystem>();
        lootSystem.CalculateDrop(transform);
        hud.Frag();
        Destroy(gameObject);
    }
}

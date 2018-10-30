using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public int health = 3;

    public BossWeapon enemyWeapon;
    private HUD hud;



    public float shootingRate = 2f;
    public float laserShotRarity = 80f;
    private float shootCooldown;

    [HideInInspector]
    public bool stopped = false;

    void Start()
    {
        hud = FindObjectOfType<HUD>();
        shootCooldown = Random.Range(2f, 6f);
        PlayerStats player = FindObjectOfType<PlayerStats>();
        health = player.damage * 100;
    }

    void Update()
    {

        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
            Move();
        }
        else
        {
            Attack();
        }
    }

    public void Move()
    {
        return;
    }

    public void Attack()
    {
        if (CanAttack)
        {
            shootingRate = Random.Range(2f, 6f);
            shootCooldown = shootingRate;
            int chance = Random.Range(0, 101);

            if (chance > laserShotRarity)
            {
                enemyWeapon.ShootLaser();
            }
            else
            {
                enemyWeapon.Shoot();
            }
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
        hud.AddScore(1300);
        Destroy(gameObject);
    }
}

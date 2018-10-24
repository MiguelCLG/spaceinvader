using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    private readonly int maxHearts = 3;
    public int startHearts = 3;
    public int health = 3;
    public int damage = 1;
    public int healthPerHeart = 1;

    private HUD hud;

    public Image[] healthImages;
    public Sprite[] healthSprites;

    Animator animator;

    // Use this for initialization

    private void Start()
    {
        hud = FindObjectOfType<HUD>();
        animator = GetComponent<Animator>();
        CheckHealthAmount();
    }
    void CheckHealthAmount()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            if (startHearts <= i)
            {
                healthImages[i].enabled = false;
            }
            else {
                healthImages[i].enabled = true;
            }
        }
        UpdateHearts();
    }

    void UpdateHearts()
    {
        bool empty = false;
        int i = 0;

        foreach (Image image in healthImages)
        {
            if (empty)
            {
                image.sprite = healthSprites[0];
            }
            else {
                i++;
                if (health >= i)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - health));
                    int healthPerImage = 1 / healthSprites.Length - 1;
                    int imageIndex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "enemy-bullet")
        {
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        
        health -= 1;
        animator.SetBool("TakeDamage", true);
        if (health <= 0)
        {
            Die();
        }
        else
        {
            UpdateHearts();
        }
    }
    void AnimationEnded()
    {
        animator.SetBool("TakeDamage", false);
    }

    public void AddDamage()
    {
        damage++;
    }
    public void AddHeartContainer()
    {
        health = Mathf.Clamp(startHearts, 0, maxHearts);
        CheckHealthAmount();
    }

    void Die()
    {
        Destroy(gameObject);
        Time.timeScale = 0f;
        hud.GameOver();
    }
}

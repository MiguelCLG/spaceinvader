using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    private int maxHearts = 3;
    public int startHearts = 3;
    public int maxHealth = 3;
    public int health = 3;

    public int healthPerHeart = 1; 

    public Text lives;
    public Image[] healthImages;
    public Sprite[] healthSprites;

    // Use this for initialization

    private void Start()
    {
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
    public void TakeDamage()
    {
        health -= 1;
        UpdateHearts();
        if (health <= 0)
        {
            Die();
        }
        else
        {
            lives.text = health.ToString();
        }
    }

    public void AddHeartContainer()
    {
        startHearts++;
        startHearts = Mathf.Clamp(startHearts, 0, maxHearts);
        CheckHealthAmount();
    }
    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 1000f;

    private Rigidbody2D rb;
    private Vector3 camPos;
    private float minX, maxX, minY, maxY;
    public GameObject impactEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update () {
        rb.velocity = transform.right * speed * Time.deltaTime;
        HitWall();
	}

    void HitWall() {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);//Performance heavy 

        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));//Performance heavy 
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));//Performance heavy 

        Vector3 pos = transform.position;// Current Position - Keep this in here - The position has to update every Update Method.

        maxY = topCorner.y;//Performance heavy 
        minY = bottomCorner.y;
        if (pos.y > maxY) Destroy(gameObject);
        if (pos.y < minY) Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && gameObject.tag != "enemy-bullet")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.TakeDamage(1);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (collision.name == "Player" && gameObject.tag != "player-bullet") {
            //PlayerStats player = collision.GetComponent<PlayerStats>();
            //player.TakeDamage();
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }


    }
}

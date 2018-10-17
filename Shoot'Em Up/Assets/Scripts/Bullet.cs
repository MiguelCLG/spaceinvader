using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 1000f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update () {
        rb.velocity = transform.right * speed * Time.deltaTime;
        if (transform.position.y > 5)
        {
            Destroy(gameObject);
        }
	}
}

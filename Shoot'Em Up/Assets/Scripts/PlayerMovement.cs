using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public HUD hud;
    private Rigidbody2D rb;
    private Vector3 camPos;



    public float speed = 10f;
    private float minX, maxX, minY, maxY;

private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update () {
        MovementRestriction();
    }

    void MovementRestriction() {

        //Performance heavy - if performance drops move this to start position and find a way to keep it Landscape/Portrait when resolution changes
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);//Performance heavy 

        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));//Performance heavy 
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));//Performance heavy 


        Vector3 pos = transform.position;// Current Position - Keep this in here - The position has to update every Update Method.

        minX = bottomCorner.x;//Performance heavy 
        maxX = topCorner.x;//Performance heavy 
        minY = bottomCorner.y;//Performance heavy 
        maxY = topCorner.y;//Performance heavy 


        // Horizontal contraint
        if (pos.x < minX) pos.x = minX;
        if (pos.x > maxX) pos.x = maxX;

        // vertical contraint
        if (pos.y < minY) pos.y = minY;
        if (pos.y > maxY) pos.y = maxY;

        // Update position
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        if (!hud.initialSpawn)
        {
            Move();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A)))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D)))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.W)))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey(KeyCode.S)))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}

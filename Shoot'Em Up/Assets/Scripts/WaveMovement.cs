using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour {

    public float speed = 3f;

    private float minX, maxX, minY, maxY;
    private string lr;

    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = "Left";
    }

    // Update is called once per frame
    void Update()
    {
        MoveChange();
        Move();
    }

    void Move()
    {

        if (lr == "Right")
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (lr == "Left")
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

    }
    void MoveChange()
    {

        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);//Performance heavy 

        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));//Performance heavy 
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));//Performance heavy 


        Vector3 pos = transform.position;// Current Position - Keep this in here - The position has to update every Update Method.

        minX = bottomCorner.x;//Performance heavy 
        maxX = topCorner.x;//Performance heavy 
        minY = bottomCorner.y;//Performance heavy 
        maxY = topCorner.y;//Performance heavy 


        // Horizontal contraint
        if (pos.x < minX) lr = "Left";
        if (pos.x > maxX) lr = "Right";

        // vertical contraint
        if (pos.y < minY) pos.y = minY;
        if (pos.y > maxY) pos.y = maxY;

        // Update position
        transform.position = pos;
    }
}

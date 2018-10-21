using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour {

    public float speed = 1f;

    private float minX, maxX, minY, maxY;
    private string lr, ud;
    private HUD hud;
    private GameObject gameSystem;

    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        gameSystem = GameObject.FindGameObjectWithTag("game-system");
        hud = gameSystem.GetComponent<HUD>();
        rb = GetComponent<Rigidbody2D>();
        lr = "Left";
        ud = "Up";
        minX = transform.position.x - 1f;
        maxX = transform.position.x + 1f;
        maxY = transform.position.y + 0.5f;
        minY = transform.position.y - 0.5f;
    }

    void Update()
    {
        if (hud.spawning == 0)
        {
            MoveChange();
            Move();
        }
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
        if (ud == "Down")
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (ud == "Up")
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

    }
    void MoveChange()
    {

        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);//Performance heavy 

        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));//Performance heavy 
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));//Performance heavy 


        Vector3 pos = transform.position;// Current Position - Keep this in here - The position has to update every Update Method.

        /*minX = bottomCorner.x;//Performance heavy 
        maxX = topCorner.x;//Performance heavy 
        minY = bottomCorner.y;//Performance heavy
        maxY = topCorner.y;//Performance heavy */
       

      /*  Debug.Log("MinX:" + minX + "MaxX: " + maxX);
        Debug.Log("MinY:" + minY + "MaxY: " + maxY);
        Debug.Log("PosX: " + pos.x + "PosY: " + pos.y);
        */
        // Horizontal contraint
        if (pos.x < minX) lr = "Left";
        if (pos.x > maxX) lr = "Right";

        // vertical contraint
        if (pos.y < minY) ud = "Down";
        if (pos.y > maxY) ud = "Up";

        // Update position
        transform.position = pos;
    }
}

using UnityEngine;


public class Item : MonoBehaviour {

    public string effectName;

    public int dropRarity;

    public GameObject itemPrefab;

    float maxY, minY;

    public void Update()
    {
        Move();
        HitWall();
    }

    private void Move()
    {
        transform.position += Vector3.down * 10f * Time.deltaTime;
    }
    void HitWall()
    {
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
        if (collision.name == "Player") {
            PlayerStats player = collision.GetComponent<PlayerStats>();
            if (effectName == "DMG+1")
            {
                player.AddDamage();
            }
            else if (effectName == "Health+1")
            {
                player.AddHeartContainer();
            }
            Destroy(gameObject);
        }
        return;
    }
}

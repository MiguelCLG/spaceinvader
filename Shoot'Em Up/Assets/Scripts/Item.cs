using UnityEngine;


public class Item : MonoBehaviour {

    public string effectName;

    public int dropRarity;

    public GameObject itemPrefab;

    public void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += Vector3.down * 10f * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") {
            PlayerStats player = collision.GetComponent<PlayerStats>();
            Debug.Log(effectName);
            if (effectName == "DMG+1")
            {
                player.AddDamage();
            }
            else if (effectName == "Health+1")
            {
                player.AddHeartContainer();
            }
        }
        Destroy(gameObject);
        return;
    }
}

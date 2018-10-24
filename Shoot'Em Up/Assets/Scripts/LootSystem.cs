using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSystem : MonoBehaviour {

    public Item[] items;


   public void CalculateDrop(Transform enemyTransform) {
        int calc_dropChance = Random.Range(0, 101);
        int itemIndex = Mathf.Abs(Random.Range(0, 2));
            if (calc_dropChance > items[itemIndex].dropRarity)
            {
                DropItem(items[itemIndex], enemyTransform);
            }
        
    }

    public void DropItem(Item item, Transform enemyTransform) {
        Instantiate(item.itemPrefab, enemyTransform.position, enemyTransform.rotation);
        return;
    }
}

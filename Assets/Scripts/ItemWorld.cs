using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemWorld : MonoBehaviour {
    
    public static ItemWorld SpawnItemWorld(Vector3 position, ItemCount item) {
    Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
    
    
    ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
    itemWorld.SetItem(item);

    return itemWorld;
    }
    private ItemCount item;
    private SpriteRenderer spriteRenderer;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
   public void SetItem(ItemCount item) {
       this.item = item;
       spriteRenderer.sprite = item.GetSprite();
   }
   public ItemCount GetItem(){
       return item;
    }
    public void DestroySelf() {
        Destroy(gameObject);
     }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemCount {
//THIS IS THE ITEM SCRIPT ITEM COUNT = ITEM 
[SerializeField] private KeyType keyType;
public enum ItemType {
    Key,
    Potion, 
}

public ItemType itemType;
public int amount;
   
    public enum KeyType {
       main,
    }
    public KeyType GetKeyType() {
        return keyType;
    }

    
public Sprite GetSprite() {
    switch (itemType) {
        default:
        case ItemType.Key: return ItemAssets.Instance.keySprite;
        case ItemType.Potion: return ItemAssets.Instance.potionSprite;
    }
}

public bool IsStackable() {
    switch (itemType) {
        default:
        case ItemType.Key:
        case ItemType.Potion:
        return true;
    }
}

}

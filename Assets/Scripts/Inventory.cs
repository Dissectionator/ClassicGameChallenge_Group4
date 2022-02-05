using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory {

    public event EventHandler OnItemListChanged;
    private List<ItemCount> itemList;

    public Inventory() {
        itemList = new List<ItemCount>();

        
    }
    public void AddItem(ItemCount item) {
        if (item.IsStackable()) {
            bool itemAlreadyInInventory = false;
foreach (ItemCount inventoryItem in itemList) {
    if(inventoryItem.itemType == item.itemType) {
        inventoryItem.amount += item.amount;
        itemAlreadyInInventory = true;
    }
}
if(!itemAlreadyInInventory) {
    itemList.Add(item);
    }
        } else {
itemList.Add(item);
        }
        
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public List<ItemCount> GetItemCount() {
        return itemList;
    }
}

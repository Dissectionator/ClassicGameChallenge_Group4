using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{ 
private Inventory inventory;
private Transform itemSlotContain;
private Transform itemSlotTemp;

private void Awake() {
    itemSlotContain = transform.Find("itemSlotContain");
    itemSlotTemp = itemSlotContain.Find("itemSlotTemp");
}
     public void SetInventory(Inventory inventory) {
         this.inventory = inventory;

         inventory.OnItemListChanged += Inventory_OnItemListChanged;
         RefreshInventoryItems();
         
     }
     private void Inventory_OnItemListChanged(object sender, System.EventArgs e) {
         RefreshInventoryItems();
     }
     private void RefreshInventoryItems() {
         foreach (Transform child in itemSlotContain) {
             if (child == itemSlotTemp) continue;
             Destroy(child.gameObject);
         }
         int x = 0;
         int y = 0;
         float itemSlotCellSize = 20f;
         foreach (ItemCount item in inventory.GetItemCount()) {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemp, itemSlotContain).GetComponent<RectTransform>();
         itemSlotRectTransform.gameObject.SetActive(true);

         itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
         Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
         image.sprite = item.GetSprite();

         

         x++;
         if (x > 4) {
             x = 0;
             y++;
         }
         }
     }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    
    public ItemSlot[] itemSLot;
    public ItemSO[] itemSOs;

    [SerializeField] private Transform dropPosition;

    public void UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                itemSOs[i].UseItem();
            }
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSLot.Length; i++)
        {
            if (itemSLot[i].isFull == false && itemSLot[i].itemName == itemName || itemSLot[i].quantity == 0)
            {
                int leftOverItems = itemSLot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftOverItems > 0)
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);


                    return leftOverItems;
            }
        }

        return quantity;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSLot.Length; i++)
        {
            itemSLot[i].selectedShader.SetActive(false);
            itemSLot[i].thisItemSelected = false;
        }
    }

    private void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            DropItem("Loot");
        }
    }

    public void DropItem(string itemName)
    {
        for (int i = 0; i < itemSLot.Length; i++)
        {
            if (itemSLot[i].itemName == itemName && itemSLot[i].quantity > 0)
            {
                GameObject droppedItem = new GameObject(itemName);
                SpriteRenderer spriteRenderer = droppedItem.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = itemSLot[i].itemSprite;

                // Set the drop position based on the assigned empty GameObject
                droppedItem.transform.position = dropPosition.position;

                itemSLot[i].RemoveItem();
            }
        }
    }
}

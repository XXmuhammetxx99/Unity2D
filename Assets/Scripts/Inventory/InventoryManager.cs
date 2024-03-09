using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    
    public ItemSlot[] itemSLot;

   


    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSLot.Length; i++)
        {
            if (itemSLot[i].isFull == false)
            {
                itemSLot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSLot.Length; i++)
        {
            itemSLot[i].selectedShader.SetActive(false);
            itemSLot[i].thisItemSelected = false;
        }
    }

}

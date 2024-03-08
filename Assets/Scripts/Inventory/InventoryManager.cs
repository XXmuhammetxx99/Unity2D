using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;

    public void OnPressedInventory(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            menuActivated = !menuActivated;

            InventoryMenu.SetActive(menuActivated);
        }
    }


    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        Debug.Log("itemName = " + itemName + "quantity = " + quantity + "itemSprite" + itemSprite);
    }

}

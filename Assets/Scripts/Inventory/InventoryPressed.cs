using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryPressed : MonoBehaviour
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

        else if (context.action.triggered)
        {
            menuActivated = !menuActivated;
            InventoryMenu.SetActive(menuActivated);

        }
    }
}

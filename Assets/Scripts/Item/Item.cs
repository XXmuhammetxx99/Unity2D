using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    public InventoryManager inventoryManager;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("out");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("in");
            inventoryManager.AddItem(itemName, quantity, sprite);
            Destroy(gameObject);

        }
    }
}

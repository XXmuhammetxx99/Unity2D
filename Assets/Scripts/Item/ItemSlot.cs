using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;

    //     ITEM DATA      //
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;

    [SerializeField]
    private int maxNumberOfItems;

    //     ITEM SLOT      //

    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image itemImage;

    //     ITEM DESCRIPTION SLOT      //

    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;








    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }


    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {

        // Check to see if the slot is aleady full //
        if (isFull)
            return quantity;

        // UPDATE NAME //
        this.itemName = itemName;

        // UPDATE IMAGE //
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;


        // UPDATE DESCRIPTION //
        this.itemDescription = itemDescription;

        // UPDATE QUANTITY //
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;

            // RETURN THE LEFTOVERS //
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        // UPDATE QUANITITY TEXT //
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;

       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }


    }

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
    }

    public void OnRightClick()
    {

    }


}

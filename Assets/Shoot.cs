using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform shootPosition;
    public InventoryManager inventoryManager;
    public GameObject arrowPrefab;
    public float arrowSpeed = 10f;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShootArrow();
        }
    }

    void ShootArrow()
    {
        if (inventoryManager != null)
        {
            bool foundArrow = false;

            for (int i = 0; i < inventoryManager.itemSLot.Length; i++)
            {
                if (inventoryManager.itemSLot[i].itemName == "Arrow" && inventoryManager.itemSLot[i].quantity > 0)
                {
                    foundArrow = true;
                    audioManager.PlaySFX(audioManager.shooting);


                    GameObject arrow = Instantiate(arrowPrefab, shootPosition.position, shootPosition.rotation);
                    Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D>();
                    arrowRb.velocity = shootPosition.right * arrowSpeed;

                    inventoryManager.itemSLot[i].RemoveItem();

                    // Start a coroutine to disable "Is Trigger" after 0.5 seconds
                    StartCoroutine(DisableIsTriggerAfterDelay(arrow));

                    break;
                }
            }

            if (!foundArrow)
            {
                Debug.Log("No arrows in inventory.");
            }
        }
        else
        {
            Debug.LogError("InventoryManager not assigned to Shoot script.");
        }
    }

    IEnumerator DisableIsTriggerAfterDelay(GameObject arrow)
    {
        yield return new WaitForSeconds(0.3f);

        // Access the arrow's Collider2D component and disable "Is Trigger"
        Collider2D arrowCollider = arrow.GetComponent<Collider2D>();
        arrowCollider.isTrigger = false;
    }

}

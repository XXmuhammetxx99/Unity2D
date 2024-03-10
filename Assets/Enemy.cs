using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject keyPrefab;

    public float movementRange = 5f;
    public float movementSpeed = 0.5f;

    private bool movingRight = true;
    private float initialPosition;

    private void Start()
    {
        initialPosition = transform.position.x;
    }

    private void Update()
    {
        MoveLeftAndRight();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            TransformIntoKey();
        }
    }

    private void TransformIntoKey()
    {
        // Deactivate or disable components related to the enemy
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        // Instantiate the key prefab at the same position as the enemy
        GameObject key = Instantiate(keyPrefab, transform.position, Quaternion.identity);

        // Optionally, destroy the enemy GameObject
        Destroy(gameObject);
    }
    private void MoveLeftAndRight()
    {
        Vector3 currentPosition = transform.position;

        if (movingRight)
        {
            currentPosition.x += Time.deltaTime * movementSpeed;
            if (currentPosition.x >= initialPosition + movementRange)
            {
                movingRight = false;
            }
        }
        else
        {
            currentPosition.x -= Time.deltaTime * movementSpeed;
            if (currentPosition.x <= initialPosition)
            {
                movingRight = true;
            }
        }

        transform.position = currentPosition;
    }
}

using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Arrow hit an enemy!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Arrow hit something else!");
        }
    }

}

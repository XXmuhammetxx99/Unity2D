using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    public Vector3 offset = new Vector3(0.12f, 0.5f, 0f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Transform playerTransform = other.GetComponent<Transform>();
            transform.position = playerTransform.position + offset;
            transform.parent = playerTransform;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}

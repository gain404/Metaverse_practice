using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looper : MonoBehaviour
{
    private int backCount = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Background"))
        {
            float widthOfObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfObject * backCount;
            collision.transform.position = pos;
            return;
        }
        else if (collision.GetType() == typeof(CircleCollider2D))
        {
            Destroy(collision.gameObject);
        }
    }
}

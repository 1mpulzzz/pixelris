using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBack : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            Vector2 normal = col.GetContact(0).normal;
            Vector2 direction = Vector2.Reflect(transform.right, normal).normalized;
            transform.position += new Vector3(direction.x, direction.y, 0);
            StartCoroutine(ReturnToInitialPosition());
        }
    }

    IEnumerator ReturnToInitialPosition()
    {
        yield return new WaitForSeconds(0f);
        transform.position = initialPosition;
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpForce = 20.0f;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05f)
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
    public Transform spawnPoint; // указываете спавн точку

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Тэг объекта, с которым должны произойти столкновения"))
        {
            transform.position = spawnPoint.position;
        }
    }
}

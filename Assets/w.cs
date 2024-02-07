using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w : MonoBehaviour
{
    public float speed = 2.0f;
    public float jumpForce = 10.0f;
    public float shiftSpeed = 3.0f; // �������� ��� ������� �� Shift
    public float smoothTime = 0.2f; // ����� �������� ��������� ��������
    private float currentSpeed; // ������� ��������
    private float targetSpeed; // ������� ��������
    private float smoothVelocity; // ���������� ��� �������� ��������� ��������
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
        targetSpeed = speed;
    }

    void Update()
    {
        float movement = Input.GetAxis("Horizontal") * currentSpeed;
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05f)
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        if (Input.GetKeyDown(KeyCode.LeftShift) && Mathf.Abs(rb.velocity.y) < 0.05f)
        {
            targetSpeed = shiftSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            targetSpeed = speed;
        }

        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref smoothVelocity, smoothTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("block") && currentSpeed > speed)
        {
            currentSpeed = speed;
        }
    }
    public Transform spawnPoint; // ���������� ����� �����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("��� �������, � ������� ������ ��������� ������������"))
        {
            transform.position = spawnPoint.position;
        }
    }
}

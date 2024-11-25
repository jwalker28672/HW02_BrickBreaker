using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    private float maxAngle = 75f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMovement();
    }

    private void horizontalMovement()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x >= -8.3 && mousePosition.x <= 8.3)
        {
            rb.transform.position = new Vector2(mousePosition.x, rb.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            Vector2 position = transform.position;
            Vector2 contact = collision.GetContact(0).point;

            float offset = position.x - contact.x;
            float length = collision.otherCollider.bounds.size.x / 2;

            float curAngle = Vector2.SignedAngle(Vector2.up,collision.rigidbody.velocity);
            float bounceAngle = (offset / length) * maxAngle;
            float newAngle = Mathf.Clamp(curAngle + bounceAngle, -maxAngle, maxAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            collision.rigidbody.velocity = rotation * Vector2.up * collision.rigidbody.velocity.magnitude;
        }
    }
}

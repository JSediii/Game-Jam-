using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 12.5f;

    private Rigidbody2D rb;
    private Collider2D circleMovement;

    public float bounceForce = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleMovement = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (circleMovement.OverlapPoint(mousePosition))
            {
                HandleMovement(mousePosition);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = Mathf.Lerp(velocity.x, 0, 0);
        velocity.y = Mathf.Lerp(velocity.y, 0, 0);
        rb.velocity = velocity;
    }

    private void HandleMovement(Vector2 mousePosition)
    {
        Vector2 circleCenter = (Vector2)transform.position;
        Vector2 direction = (mousePosition - circleCenter).normalized;
        float distance = Vector2.Distance(mousePosition, circleCenter);
        float circleRadius = GetComponent<CircleCollider2D>().radius * transform.localScale.x;

        if (distance < circleRadius)
        {
            // Clicked inside the circle
            if (Mathf.Abs(direction.x) < 0.5f && direction.y > 0f) // Middle part of the circle
            {
                rb.velocity = new Vector2(rb.velocity.y, bounceForce);
            }
            else
            {
                if (direction.y > 0) // Upper part of the circle
                {
                    rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
                }
                else if (direction.y < 0) // Bottom part of the circle
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }

                if (direction.x < 0) // Left side of the circle
                {
                    rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                }
                else if (direction.x > 0) // Right side of the circle
                {
                    rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                }

            }
        }

    }
}

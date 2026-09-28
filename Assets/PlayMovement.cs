using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    // player is touching the platform
    private bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // simple aswd movement but we have jump 
    void Update()
    {
        float move = 0;

        if (Keyboard.current.aKey.isPressed)
        {
            move = -1;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            move = 1;
        }

        rb.linearVelocity =
            new Vector2(move * speed, rb.linearVelocity.y);

        if ((Keyboard.current.spaceKey.wasPressedThisFrame ||
             Keyboard.current.wKey.wasPressedThisFrame)
             && grounded)
        {
            rb.linearVelocity =
                new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    //checks if the player is touching the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}

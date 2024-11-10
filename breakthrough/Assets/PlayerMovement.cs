using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of horizontal movement
    public float jumpForce = 5f; // Force applied for jumping

    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private bool isGrounded = false; // Tracks whether the character is on the ground
    private bool isFacingRight = true; // Tracks the direction the character is facing

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }

    void Update()
    {
        // Handle horizontal movement
        float moveInput = Input.GetAxis("Horizontal"); // Get input for left/right movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // Apply velocity

        // Flip the character if moving in the opposite direction
        if (moveInput > 0 && !isFacingRight)
        {
            FlipCharacter();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            FlipCharacter();
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply jump force
        }
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight; // Toggle the facing direction
        Vector3 scale = transform.localScale; // Get the current scale of the player
        scale.x *= -1; // Flip the scale on the x-axis
        transform.localScale = scale; // Apply the flipped scale
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has landed on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player has left the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

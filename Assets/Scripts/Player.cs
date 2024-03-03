using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control the speed of the player
    public float interactionRadius = 1f; // Adjust this value to control the interaction radius

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Movement
        Vector2 movement = new Vector2(moveX, moveY).normalized;
        rb.velocity = movement * moveSpeed;

        // Interaction
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InteractWithObjects();
        }
    }

    private void InteractWithObjects()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
        
        foreach (Collider2D collider in colliders)
        {
            // Check if the collider belongs to an object that can be picked up
            PickUpObject pickableObject = collider.GetComponent<PickUpObject>();
            if (pickableObject != null)
            {
                // Pick up the object
                pickableObject.PickUp();
            }
        }
    }

    // Draw a gizmo to visualize the interaction radius (for debugging)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}

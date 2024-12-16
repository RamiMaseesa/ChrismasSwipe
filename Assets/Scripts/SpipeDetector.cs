using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpipeDetector : MonoBehaviour
{
    private Vector2 previousMousePosition; // To track the previous frame's mouse position
    public LayerMask fruitLayer;          // Assign a layer for fruits to filter raycasts
    public float pushForce = 5f;
    
    void Update()
    {
        // Check if the mouse is pressed or held down
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (previousMousePosition != Vector2.zero)
            {
                // Perform a raycast along the swipe path
                RaycastHit2D hit = Physics2D.Raycast(previousMousePosition, currentMousePosition - previousMousePosition,
                    Vector2.Distance(previousMousePosition, currentMousePosition), fruitLayer);

                if (hit.collider != null)
                {
                    // Check if the object hit is a fruit
                    if (hit.collider.CompareTag("Fruit"))
                    {
                        Debug.Log("Fruit swiped: " + hit.collider.gameObject.name);

                        // Calculate horizontal push direction
                        Rigidbody2D fruitRb = hit.collider.GetComponent<Rigidbody2D>();
                        if (fruitRb != null)
                        {
                            Vector2 pushDirection;
                            if (currentMousePosition.x > hit.collider.transform.position.x)
                            {
                                // Push left if the mouse is to the right of the fruit
                                pushDirection = Vector2.left;
                            }
                            else
                            {
                                // Push right if the mouse is to the left of the fruit
                                pushDirection = Vector2.right;
                            }

                            // Apply the force, ensuring only horizontal movement
                            fruitRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
                        }
                    }
                }
            }

            // Update the previous mouse position
            previousMousePosition = currentMousePosition;
        }
        else
        {
            // Reset the previous mouse position when the mouse is not pressed
            previousMousePosition = Vector2.zero;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    public float upwardForce = 5f;      // Force applied upward
    public float sidewaysForce = 2f;   // Force applied to the side
    public float rotationForce = 10f;  // Torque for slight rotation

    private Rigidbody2D rb;

    private float time;
    
    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Randomize the sideways force to be either positive or negative
        float randomizedSidewaysForce = Random.Range(-Mathf.Abs(sidewaysForce), Mathf.Abs(sidewaysForce));

        // Apply the upward and randomized sideways force
        Vector2 force = new Vector2(randomizedSidewaysForce, upwardForce);
        rb.AddForce(force, ForceMode2D.Impulse);

        // Randomize the rotation force to be either positive or negative
        float randomizedRotationForce = Random.Range(-Mathf.Abs(rotationForce), Mathf.Abs(rotationForce));

        // Apply the randomized rotation force
        rb.AddTorque(randomizedRotationForce, ForceMode2D.Impulse);
    }

    void Update() {
        
        time += Time.deltaTime;

        if (time > 5)
        {
            Destroy(this.gameObject);
        }
        
    }
}

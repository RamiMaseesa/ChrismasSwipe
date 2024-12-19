using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderDetection : MonoBehaviour
{
    public ObjectValues Values;
    private Vector2 screenBounds; // Stores the screen boundaries in world units
    private float objectWidth;    // Half the width of the object
    private float objectHeight;   // Half the height of the object
    public GameObject yes;
    public GameObject no;
    
    public ScoreManager scoreManager;
    public HeartSystem heartSystem;
    
    private float time;
    private bool spawend = false;

    void Start()
    {
        scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
        heartSystem = GameObject.Find("Canvas").GetComponent<HeartSystem>();
        
        
        Values = GetComponent<ObjectValues>();
                
        // Calculate the screen bounds using the camera
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Calculate the object's dimensions
        objectWidth = transform.localScale.x / 2; // Assuming the object has no rotation and uses a uniform scale
        objectHeight = transform.localScale.y / 2;
    }

    void Update()
    {
        time += Time.deltaTime;
        
        if (time < 0.5f || spawend) return;
        
        // Check if the object has reached the left or right border
        if (transform.position.x + objectWidth > screenBounds.x || transform.position.x - objectWidth < -screenBounds.x)
        {
            if (Values.hitMe)
            {

                if (Values.score == -1)
                {
                    // Instantiate the object
                    GameObject spawnedObject = Instantiate(no, transform.position, Quaternion.identity);

                    // Destroy the object after 10 seconds
                    Destroy(spawnedObject, 1f);
                    heartSystem.heartCount -= 1;
                }
                else
                {
                    // Instantiate the object
                    GameObject spawnedObject = Instantiate(yes, transform.position, Quaternion.identity);

                    // Destroy the object after 10 seconds
                    Destroy(spawnedObject, 1f);
                    scoreManager.score += 100;
                }

                
                spawend = true;
            }
            else
            {
                
                if (Values.score == -1)
                {
                    // Instantiate the object
                    GameObject spawnedObject = Instantiate(yes, transform.position, Quaternion.identity);

                    // Destroy the object after 10 seconds
                    Destroy(spawnedObject, 1f);
                    scoreManager.score += 100;
                }
                else
                {
                    // Instantiate the object
                    GameObject spawnedObject = Instantiate(no, transform.position, Quaternion.identity);

                    // Destroy the object after 10 seconds
                    Destroy(spawnedObject, 1f);
                    heartSystem.heartCount -= 1;
                }
                
                
                spawend = true;
            }
        }
        else if (transform.position.y + objectHeight > screenBounds.y || transform.position.y - objectHeight < -screenBounds.y)
        {
            if (Values.hitMe)
            {

                if (Values.score == -1)
                {
                    // Instantiate the object
                    GameObject spawnedObject = Instantiate(no, transform.position, Quaternion.identity);

                    // Destroy the object after 10 seconds
                    Destroy(spawnedObject, 1f);
                    heartSystem.heartCount -= 1;
                }
                else
                {
                    // Instantiate the object
                    GameObject spawnedObject = Instantiate(yes, transform.position, Quaternion.identity);

                    // Destroy the object after 10 seconds
                    Destroy(spawnedObject, 1f);
                    scoreManager.score += 100;
                }

                
                spawend = true;
            }
            else
            {
                
                if (Values.score == -1)
                {
                    // Instantiate the object
                    GameObject spawnedObject = Instantiate(yes, transform.position, Quaternion.identity);

                    // Destroy the object after 10 seconds
                    Destroy(spawnedObject, 1f);
                    scoreManager.score += 100;
                }
                else
                {
                    // Instantiate the object
                    GameObject spawnedObject = Instantiate(no, transform.position, Quaternion.identity);

                    // Destroy the object after 10 seconds
                    Destroy(spawnedObject, 1f);
                    heartSystem.heartCount -= 1;
                }
                
                
                spawend = true;
            }
        }
    }
}

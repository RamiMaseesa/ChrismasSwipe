using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnFruitsSC : MonoBehaviour
{
    public GameObject[] objectToSpawn;  // The prefab to spawn
    public BoxCollider2D spawnArea;  // The 2D collider where objects will be spawned
    public float spawnInterval = 0.5f; // Time in seconds between spawns

    void Start()
    {
        StartCoroutine(SpawnObjectsContinuously());
        
        
    }

    IEnumerator SpawnObjectsContinuously()
    {
        while (true) // Infinite loop
        {
            // Generate a random position within the BoxCollider2D
            Vector2 randomPosition = GetRandomPointInBox(spawnArea);
            
            int index = Random.Range(0, objectToSpawn.Length);
            
            // Instantiate the object at the random position
            Instantiate(objectToSpawn[index], randomPosition, Quaternion.identity);
            
            // Wait for the specified interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector2 GetRandomPointInBox(BoxCollider2D box)
    {
        // Get the bounds of the BoxCollider2D
        Bounds bounds = box.bounds;

        // Generate random positions within the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(x, y);
    }
}

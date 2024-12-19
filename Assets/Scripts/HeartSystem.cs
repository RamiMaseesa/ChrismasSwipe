using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeartSystem : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    
    public int heartCount = 3;

    // Update is called once per frame
    void Update()
    {
        if (heartCount == 2)
        {
            Destroy(heart3);
        }
        else if(heartCount == 1)
        {
            Destroy(heart2);
        }
        else if (heartCount == 0)
        {
            SceneManager.LoadScene("LuukScene");
        }
    }
}

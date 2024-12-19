using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioClip[] songs; // Array to hold the songs
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        if (songs.Length > 0)
        {
            PlayRandomSong();
        }
        else
        {
            Debug.LogWarning("No songs assigned in the array!");
        }
    }

    void Update()
    {
        // Check if the song has finished playing
        if (!audioSource.isPlaying && songs.Length > 0)
        {
            PlayRandomSong();
        }
    }

    void PlayRandomSong()
    {
        // Select a random song index
        int randomIndex = Random.Range(0, songs.Length);
        audioSource.clip = songs[randomIndex];

        // Play the selected song
        audioSource.Play();
        
    }
}

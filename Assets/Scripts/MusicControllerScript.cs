using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControllerScript : MonoBehaviour
{
    //Background soundtrack
    public AudioSource[] tracks;

    //Current song
    private int songIndex;

    //Proposed next song
    private int newSongIndex;

    // Start is called before the first frame update
    void Start()
    {
        //Start playing a random track
        songIndex = Random.Range(0, tracks.Length);
        tracks[songIndex].Play();

        //Determine the next song
        newSongIndex = Random.Range(0, tracks.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //Play a new song if the current song is over
        if (!tracks[songIndex].isPlaying)
        {
            //Ensure that the new song is different from the current song
            while (newSongIndex == songIndex)
            {
                newSongIndex = Random.Range(0, tracks.Length);
            }
            songIndex = newSongIndex;
            tracks[songIndex].Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour {

    public AudioClip[] BackgroundMusicTracks;

    private AudioSource background;
    private int currentlyPlaying;

	// Use this for initialization
	void Start () {
        background = GetComponent<AudioSource>();
        PlayNextTrack();
	}
	
	// Update is called once per frame
	void Update () {
		if (background.isPlaying == false)
        {
            currentlyPlaying++;
            if (currentlyPlaying == BackgroundMusicTracks.Length)
            {
                currentlyPlaying = 0;
            }
            PlayNextTrack();
        }

    }

    private void PlayNextTrack()
    {
        background.clip = BackgroundMusicTracks[currentlyPlaying];
        background.Play();
    }
}

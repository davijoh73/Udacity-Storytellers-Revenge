using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderVideoControls : MonoBehaviour
{

    private UnityEngine.Video.VideoPlayer videoPlayer;
    public GameObject pauseSplash; //splash screen that displays "Paused" text on screen
    public GameObject choiceSplash; //splash screen that displays choice of beach or under the falls
    

    [SerializeField]
    private AudioSource audioSource;
    

    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();


        if (videoPlayer.clip != null)
        {
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.SetTargetAudioSource(0, audioSource);
        }
    }

    //Check if input keys have been pressed and call methods accordingly.
    void Update()
    {
        //Play or pause the video from user input
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0) && (videoPlayer.time <= 17.00 || videoPlayer.time >= 19.00))
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                audioSource.Pause();
                pauseSplash.SetActive(true);
            }

            else
            { 
                videoPlayer.Play();
                audioSource.Play();
                pauseSplash.SetActive(false);
            }
        }

        //Debug.Log("video player time: " + videoPlayer.time);

        if (videoPlayer.time >= 18.00)
        {
            videoPlayer.Pause();
            audioSource.Pause();
            choiceSplash.SetActive(true);
        }

    }

}
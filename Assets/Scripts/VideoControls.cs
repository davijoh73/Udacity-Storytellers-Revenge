using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControls : MonoBehaviour
{

    private UnityEngine.Video.VideoPlayer videoPlayer;
    private UnityEngine.Video.VideoClip videoClip;
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
            videoClip = videoPlayer.clip;
            Debug.Log("video lenght: " + videoClip.length);
        }
    }

    //Check if input keys have been pressed and call methods accordingly.
    void Update()
    {
        //Play or pause the video from user input
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
                pauseSplash.SetActive(true);
            }

            else
            { 
                videoPlayer.Play();
                pauseSplash.SetActive(false);
                //audioSource.Play();

            }
        }

        Debug.Log("video player time: " + videoPlayer.time);

        if (videoPlayer.time == videoClip.length)
        {
            videoPlayer.Pause();
            choiceSplash.SetActive(true);
        }

    }

    public void goToBeach()
    {
        videoPlayer.url = "http://www.skywarp.co/ToTheBeach.mp4";
        choiceSplash.SetActive(false);
        videoPlayer.Play();
    }

    public void goToUnderFalls()
    {
        videoPlayer.url = "http://www.skywarp.co/UnderTheFalls.mp4";
        choiceSplash.SetActive(false);
        videoPlayer.Play();
    }
}
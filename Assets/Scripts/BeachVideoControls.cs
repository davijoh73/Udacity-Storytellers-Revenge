using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeachVideoControls : MonoBehaviour
{

    private UnityEngine.Video.VideoPlayer videoPlayer;
    public GameObject pauseSplash; //splash screen that displays "Paused" text on screen
    public GameObject endSplash; //splash screen that displays choice of beach or under the falls
    private float count = 2f;

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
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0) && (videoPlayer.time <= 87.00 || videoPlayer.time >= 89.00))
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

        else if (Input.GetMouseButton(0))
        {
            count -= Time.deltaTime;
            if (count < 0)
            {
                SceneManager.LoadScene("WaterfallAdventure");
                count = 2f;
            }

        }

        else if (Input.GetMouseButtonUp(0))
        {
            count = 2f;
        }

        //Debug.Log("video player time: " + videoPlayer.time);

        if (videoPlayer.time >= 88.00)
        {
            videoPlayer.Pause();
            audioSource.Pause();
            endSplash.SetActive(true);
        }

    }

}
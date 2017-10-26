using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {

    public void changeVideo(string videoName)
    {
        SceneManager.LoadScene(videoName);
    }
}

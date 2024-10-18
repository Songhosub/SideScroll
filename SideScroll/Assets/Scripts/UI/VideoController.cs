using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    GameObject Background;
    GameObject GameManager;
    GameObject Video;
    VideoPlayer vid;
    
    // Start is called before the first frame update
    void Start()
    {
        Background = GameObject.Find("Canvas/Background");
        GameManager = GameObject.Find("GameManager");
        Video = GameObject.Find("Canvas/Video");
        vid = GameObject.FindGameObjectWithTag("Video").GetComponent<VideoPlayer>();

        GameManager.SetActive(false);
        Video.SetActive(false);
        Invoke("DestroyBackground", 0.2f);

        if (SceneManager.GetActiveScene().name == "1Stage")
        { 
            if (Main.Stage1)
            {
                Video.SetActive(true);
                Main.Stage1 = false;
                Invoke("VideoEnd", (float)vid.clip.length);
            }
            else
            {
                GameManager.SetActive(true);
            }
        }
        else if (SceneManager.GetActiveScene().name == "2Stage")
        {
            if (Main.Stage2)
            {
                Video.SetActive(true);
                Main.Stage2 = false;
                Invoke("VideoEnd", (float)vid.clip.length);
            }
            else
            {
                GameManager.SetActive(true);
            }
        }
        else
        {
            if (Main.Stage3)
            {
                Video.SetActive(true);
                Main.Stage3 = false;
                Invoke("VideoEnd", (float)vid.clip.length);
            }
            else
            {
                GameManager.SetActive(true);
            }
        }
    }

    void DestroyBackground()
    {
        Background.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void VideoEnd()
    {
        Video.SetActive(false);
        GameManager.SetActive(true);
    }
 }

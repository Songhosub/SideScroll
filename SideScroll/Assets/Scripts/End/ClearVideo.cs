using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class ClearVideo : MonoBehaviour
{
    GameObject Background;
    GameObject End;
    VideoPlayer Video1;
    VideoPlayer Video2;

    // Start is called before the first frame update
    void Start()
    {
        Background = GameObject.Find("Canvas/Background");
        End = GameObject.Find("Canvas/End");
        Video1 = GameObject.Find("Video1").GetComponent<VideoPlayer>();
        Video2 = GameObject.Find("Video2").GetComponent<VideoPlayer>();

        Video2.gameObject.SetActive(false);
        End.SetActive(false);
        Invoke("DestroyBackground", 0.2f);

        Video1.Play();
        Invoke("Play2", (float)Video1.clip.length);

        End.GetComponent<Button>().onClick.AddListener(StartScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyBackground()
    {
        Background.SetActive(false);
    }

    void Play2()
    {
        Video1.gameObject.SetActive(false);
        Video2.gameObject.SetActive(true);
        Video2.Play();
        Invoke("END", (float)Video2.clip.length);
    }
    void END()
    {
        End.SetActive(true);
    }

    void StartScene()
    {
        Main.HPvalue = 35;
        Main.LifeValue = 4;
        SceneManager.LoadScene("Start");
    }
}

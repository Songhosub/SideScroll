using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    GameObject Background;
    GameObject Intro;
    GameObject StartMain;
    Button SkipBtn;
    Button StartBtn;
    Button EndBtn;

    // Start is called before the first frame update
    void Start()
    {
        Background = GameObject.Find("Canvas/Background");
        Intro = GameObject.Find("Canvas/Intro");
        StartMain = GameObject.Find("Canvas/Main");
        SkipBtn = GameObject.Find("Canvas/Intro/Skip").GetComponent<Button>();
        StartBtn = GameObject.Find("Canvas/Main/Start").GetComponent<Button>();
        EndBtn = GameObject.Find("Canvas/Main/End").GetComponent<Button>();

        SkipBtn.onClick.AddListener(Skip);
        StartBtn.onClick.AddListener(GameStart);
        EndBtn.onClick.AddListener(GameEnd);

        Intro.SetActive(false);
        StartMain.SetActive(false);
        Invoke("DestroyBackground", 0.2f);

        if (Main.Intro)
        {
            Intro.SetActive(true);
            Main.Intro = false;
            Invoke("Skip", 39.2f);
        }
        else
        {
            StartMain.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyBackground()
    {
        Background.SetActive(false);
    }

    void Skip()
    {
        Intro.SetActive(false);
        StartMain.SetActive(true);
    }

    void GameStart()
    {
        SceneManager.LoadScene("1Stage");
    }

    void GameEnd()
    {
        #if UNITY_EDITOR
             UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

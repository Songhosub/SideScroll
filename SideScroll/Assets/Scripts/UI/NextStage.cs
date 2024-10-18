using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextStage : MonoBehaviour
{
    GameObject Player;
    Text Stage;
    GameObject ClearPop;
    Button ClearBtn;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Unit");
        Stage = GameObject.Find("Canvas/Panel/Stage").GetComponent<Text>();
        ClearPop = GameObject.Find("Canvas/ClearPop");
        ClearBtn = GameObject.Find("Canvas/ClearPop/Button").GetComponent<Button>();
        ClearBtn.onClick.AddListener(NestStage);
        ClearPop.SetActive(false);

        if (SceneManager.GetActiveScene().name == "1Stage")
        {
            Stage.text = ("1");
        }
        else if(SceneManager.GetActiveScene().name == "2Stage")
        {
            Stage.text = ("2");
        }
        else if (SceneManager.GetActiveScene().name == "3Stage")
        {
            Stage.text = ("3");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            ClearPop.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    void NestStage()
    {
        ClearPop.SetActive(false);
        Time.timeScale = 1.0f;
        if (SceneManager.GetActiveScene().name == "1Stage")
        {
            SceneManager.LoadScene("2Stage");
        }
        else if (SceneManager.GetActiveScene().name == "2Stage")
        {
            SceneManager.LoadScene("3Stage");
        }
        else if (SceneManager.GetActiveScene().name == "3Stage")
        {
            if(Main.LifeValue == 4)
            {
                SceneManager.LoadScene("Clear");
            }
            else
            {
                Main.LifeValue = 4;
                Main.HPvalue = 35;
                SceneManager.LoadScene("Start");
            }
        }
    }

}

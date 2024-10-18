using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    float timer = 0;
    Slider HP;
    GameObject Player;
    public GameObject DiePrefab;
    TMP_Text LifeTxt;
    Vector3 StartPoint;
    GameObject DiePop;
    Button Die;

    // Start is called before the first frame update
    void Start()
    {
        DiePop = GameObject.Find("Canvas/DiePop");
        Die = GameObject.Find("Canvas/DiePop/Button").GetComponent<Button>();
        HP = GameObject.Find("Canvas/HPbar").GetComponent<Slider>();
        StartPoint = GameObject.Find("StartPoint").transform.position;
        LifeTxt = GameObject.Find("Canvas/Panel/Life").GetComponent<TMP_Text>();
        Player = GameObject.Find("Unit");

        DiePop.SetActive(false);

        Die.onClick.AddListener(DieScene);
        
        LifeTxt.text = Main.LifeValue.ToString();
        StartCoroutine("Loop");
    }

    private void Update()
    {
        
    }

    IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (HP.value <= 0)
            {
                if (Main.LifeValue > 1)
                {
                    Instantiate(DiePrefab, Player.transform.position, Quaternion.identity);
                    GetComponent<Unit>().enabled = false;
                    Player.GetComponent<Collider2D>().enabled = false;
                    Player.GetComponent<SpriteRenderer>().enabled = false;
                    
                    yield return new WaitForSeconds(0.6f);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    Main.LifeValue--;
                    LifeTxt.text = Main.LifeValue.ToString();
                    HP.value = 35;
                    Main.HPvalue = 35;

                }
                else
                {
                    Instantiate(DiePrefab, Player.transform.position, Quaternion.identity);
                    GetComponent<Unit>().enabled = false;
                    Player.GetComponent<Collider2D>().enabled = false;
                    Player.GetComponent<SpriteRenderer>().enabled = false;

                    yield return new WaitForSeconds(0.6f);
                    Time.timeScale = 0.0f;
                    DiePop.SetActive(true);    
                }
            }
        }
    }

    void DieScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Die");
    }
}

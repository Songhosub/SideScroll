using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    GameObject menu;
    Button MenuBtn;
    Button Yes;
    Button No;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Canvas/MenuPop");
        MenuBtn = GameObject.Find("Canvas/Panel/Menu").GetComponent<Button>();
        Yes = GameObject.Find("Canvas/MenuPop/Yes").GetComponent <Button>();
        No = GameObject.Find("Canvas/MenuPop/No").GetComponent<Button>();
        menu.SetActive(false);

        MenuBtn.onClick.AddListener(MenuPopUp);
        Yes.onClick.AddListener(MenuPopYes);
        No.onClick.AddListener(MenuPopNo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MenuPopUp()
    {
        menu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void MenuPopYes()
    {
        Time.timeScale = 1.0f;
        Main.HPvalue = 35;
        Main.LifeValue = 4;
        SceneManager.LoadScene("Start");
    }

    void MenuPopNo()
    {
        Time.timeScale = 1.0f;
        menu.SetActive(false);
    }
}

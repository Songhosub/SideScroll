using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    Slider HP;
    Image HPColor;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        HP = GameObject.Find("Canvas/HPbar").GetComponent<Slider>();
        HPColor = GameObject.Find("Canvas/HPbar/Fill Area/Fill").GetComponent<Image>();
        Player = GameObject.Find("Unit");
        HP.value = Main.HPvalue;
    }

    // Update is called once per frame
    void Update()
    {
        HP.gameObject.transform.position = Camera.main.WorldToScreenPoint(Player.transform.position + new Vector3(0, -0.5f, 0));

        if (HP.value < (35 / 4))
        {
            HPColor.color = Color.red;
        }

        else if (HP.value < (35 / 2))
        {
            HPColor.color = Color.yellow;
        }
        else
        {
            HPColor.color = Color.green;
        }
    }

    public void Hit(int damage)
    {
        Main.HPvalue -= damage;
        HP.value = Main.HPvalue;
    }
}

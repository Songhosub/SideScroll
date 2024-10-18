using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBoom : MonoBehaviour
{
    GameObject Player;
    GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Unit");
        GameManager = GameObject.Find("GameManager");
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == Player.name)
        {
            GameManager.GetComponent<HPbar>().Hit(35);
        }
    }
}

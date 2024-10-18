using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MineSpawn : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] pos;
    GameObject Player;
    GameObject[] Mine;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 60; i++)
        {

            if (i % 6 == 0)
            {
                GetRandomPosition(pos[0].position);
            }

            else if (i % 6 == 1)
            {
                GetRandomPosition(pos[1].position);
            }

            else if (i % 6 == 2)
            {
                GetRandomPosition(pos[2].position);
            }

            else if (i % 6 == 3)
            {
                GetRandomPosition(pos[3].position);
            }

            else if (i % 6 == 4)
            {
                GetRandomPosition(pos[4].position);
            }

            else
            {
                GetRandomPosition(pos[5].position);
            }
        }

        Player = GameObject.Find("Unit");
        Mine = GameObject.FindGameObjectsWithTag("Mine");

        foreach (GameObject obj in Mine)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in Mine)
        {
            if(Vector2.Distance(obj.transform.position, Player.transform.position) < 5)
            obj.SetActive(true);
        }
    }

    void GetRandomPosition(Vector2 pos)
    {
        Vector2 basePosition = pos;
        Vector2 size = new Vector2 (7, 7);

        //x, yÃà ·£´ý ÁÂÇ¥ ¾ò±â
        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);

        Vector2 spawnPos = new Vector2(posX, posY);

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}

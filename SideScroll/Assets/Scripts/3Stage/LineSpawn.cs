using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawn : MonoBehaviour
{
    GameObject Player;
    public GameObject LinePrefab;
    float time = 1.2f;
    float timer = 0.0f;
    int TankNum = 5;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Unit");
        StartCoroutine("Spawn");
    }
    /*
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > time)
        {
            for (int i = 0; i < TankNum; i++)
            {
                Vector3 pos = Player.transform.position;
                pos.x = pos.x + Random.Range(1.0f, 3.2f);
                pos.y = pos.y + Random.Range(-1.5f, 1.5f);
                Instantiate(LinePrefab, pos, Quaternion.identity);
            }
            TankNum++;
            timer = 0.0f;
        }
    }
    */
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            for (int i = 0; i < TankNum; i++)
            {
                Vector3 pos = Player.transform.position;
                pos.x = pos.x + Random.Range(1.0f, 3.2f);
                pos.y = pos.y + Random.Range(-1.5f, 1.5f);
                Instantiate(LinePrefab, pos, Quaternion.identity);
            }
            TankNum++;
            yield return new WaitForSeconds(0.6f);
        }
            
    }
}

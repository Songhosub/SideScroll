using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Bunker : MonoBehaviour
{
    public GameObject Prefab;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Unit");

        StartCoroutine("Shooting");
    }


    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);
            if (Vector3.Distance(transform.position, Player.transform.position) < 10)
            {
                Vector3 dir = Player.transform.position - transform.position;
                dir.Normalize();
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180;
                Instantiate(Prefab, transform.position, Quaternion.identity);
                if (22.5 < angle && angle <= 67.5)
                {
                    GetComponent<Animator>().SetInteger("BunkerPatameter", 225);//225

                }
                if (67.5 < angle && angle <= 112.5)
                {
                    GetComponent<Animator>().SetInteger("BunkerPatameter", 180);//180

                }
                if (112.5 < angle && angle <= 157.5)
                {
                    GetComponent<Animator>().SetInteger("BunkerPatameter", 135);

                }
                if (157.5 < angle && angle <= 202.5)
                {
                    GetComponent<Animator>().SetInteger("BunkerPatameter", 90);//90

                }
                if (202.5 < angle && angle <= 247.5)
                {
                    GetComponent<Animator>().SetInteger("BunkerPatameter", 45);//45

                }
                if (247.5 < angle && angle <= 292.5)
                {
                    GetComponent<Animator>().SetInteger("BunkerPatameter", 360);//360

                }
                if (292.5 < angle && angle <= 337.5)
                {
                    GetComponent<Animator>().SetInteger("BunkerPatameter", 315);

                }
                if (337.5 < angle && angle <= 360 || 0 <= angle && angle <= 22.5)
                {
                    GetComponent<Animator>().SetInteger("BunkerPatameter", 270);//270

                }
                yield return new WaitForSeconds(0.3f);
                GetComponent<Animator>().SetInteger("BunkerPatameter", 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    GameObject Player;
    float speed = 5;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Unit").GetComponent<Animator>();
        Player = GameObject.Find("Unit");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;

        if(h == 0 && v ==0)
        {
            anim.SetInteger("AniStep", 0);
        }

        else if (h > 0 && v == 0)
        {
            anim.SetInteger("AniStep", 90);
        }

        else if(h > 0 && v < 0)
        {
            anim.SetInteger("AniStep", 135);
        }

        else if (h == 0 && v < 0)
        {
            anim.SetInteger("AniStep", 180);
        }

        else if (h < 0 && v < 0)
        {
            anim.SetInteger("AniStep", 225);
        }

        else if (h < 0 && v == 0)
        {
            anim.SetInteger("AniStep", 270);
        }

        else if (h < 0 && v > 0)
        {
            anim.SetInteger("AniStep", 315);
        }

        else if (h == 0 && v > 0)
        {
            anim.SetInteger("AniStep", 360);
        }

        else if (h > 0 && v > 0)
        {
            anim.SetInteger("AniStep", 45);
        }
        Player.transform.Translate(Vector3.right * h);
        Player.transform.Translate(Vector3.up * v);

    }




}

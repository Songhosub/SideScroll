using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMove : MonoBehaviour
{
    GameObject GameManager;
    GameObject Player;
    Vector2 dir;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        GameManager = GameObject.Find("GameManager");
        Player = GameObject.Find("Unit");
        StartCoroutine("Chase");
        GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Chase()
    {
        float time = 0;
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
            dir = Player.transform.position - transform.position;
            dir.Normalize();

            transform.Translate(dir * 7.0f * Time.deltaTime);
            if(time > 1.5f)
            {
                break;
            }
        }
        yield return new WaitForSeconds(0.2f);
        ani.SetInteger("Boom", 1);
        GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(0.6f);
        GetComponent <Collider2D>().enabled = false;
        GetComponent <SpriteRenderer>().enabled = false;
        ani.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == Player.name)
        {
            GameManager.GetComponent<HPbar>().Hit(20);
        }
    }
}

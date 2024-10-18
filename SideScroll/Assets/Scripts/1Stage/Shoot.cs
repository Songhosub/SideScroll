using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    GameObject GameManager;
    GameObject Player;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        Player = GameObject.Find("Unit");
        dir = Player.transform.position - transform.position;
        dir.Normalize();

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 180f, Vector3.forward);
        Destroy(this.gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * 10f * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == Player.name)
        {
            GameManager.GetComponent<HPbar>().Hit(5);
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.tag != "Shoot")
        {
            Destroy(this.gameObject);
        }
    }
}

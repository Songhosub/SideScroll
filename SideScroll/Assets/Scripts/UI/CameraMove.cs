using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject Player;
    Vector3 CameraPos;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Unit");
        CameraPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraPos.x = Mathf.Clamp(Player.transform.position.x, -1.9f, 9.6f);
        Camera.main.transform.position = CameraPos;
    }
}

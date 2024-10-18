using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stagebar : MonoBehaviour
{
    Slider Stage;
    GameObject Player;
    GameObject Beacon;
    GameObject StartPoint;
    // Start is called before the first frame update
    void Start()
    {
        Stage = GameObject.Find("Canvas/Panel/Stagebar").GetComponent<Slider>();
        Player = GameObject.Find("Unit");
        Beacon = GameObject.Find("Beacon");
        StartPoint = GameObject.Find("StartPoint");

    }

    // Update is called once per frame
    void Update()
    {
        float StartPos = StartPoint.transform.position.x;
        float PlayerPos = Player.transform.position.x;
        float EndPos = Beacon.transform.position.x;

        if (PlayerPos <= StartPos)
        {
            Stage.value = 0;
        }
        if(PlayerPos >= EndPos)
        {
            Stage.value = 1;
        }
        Stage.value = (float)((PlayerPos + Mathf.Abs(StartPos)) / (Mathf.Abs(StartPos) + Mathf.Abs(EndPos)));
    }
}

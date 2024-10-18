using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartMain", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartMain()
    {
        Main.HPvalue = 35;
        Main.LifeValue = 4;
        SceneManager.LoadScene("Start");
    }
}

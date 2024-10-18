using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomSpawn : MonoBehaviour
{
    public GameObject Boom;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        Instantiate(Boom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

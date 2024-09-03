using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScieBullet : MonoBehaviour
{
    public GameObject player;
    public float speed = 100.0f;
    public int damage = 10;
    public int distance = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate around player at distance distance
        transform.RotateAround(player.transform.position, Vector3.forward, speed * Time.deltaTime);
    }
}

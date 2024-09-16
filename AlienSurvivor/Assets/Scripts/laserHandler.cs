using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserHandler : MonoBehaviour
{

    public float laserRate;
    public float laserTimer;

    public GameObject laser;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        laserTimer += Time.deltaTime;
        if (laserTimer >= laserRate)
        {
            laserTimer = 0.0f;
            fireLaser();
        }
    }

    public void fireLaser()
    {
        GameObject laser1 = Instantiate(laser, target.transform.position, Quaternion.identity);
        //rotate go straight
        laser1.transform.rotation = target.transform.rotation;
        Destroy(laser1, 2.5f);
    }


}

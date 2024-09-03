using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public int level = 1;
    public GameObject bulletPrefab;
    public List<Transform> bulletSpawns = new List<Transform>();
    public GameObject player;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CheckFire())
            return;
        if (level == 1)
            Fire(bulletSpawns[0]);
        else if (level == 2)
        {
            Fire(bulletSpawns[1]);
            Fire(bulletSpawns[2]);
        }
        else if (level == 3)
        {
            Fire(bulletSpawns[0]);
            Fire(bulletSpawns[1]);
            Fire(bulletSpawns[2]);
        }
    }

    void Fire(Transform bulletSpawn)
    {
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation * Quaternion.Euler(0, 0, 0)
                );
            bullet.GetComponent<BasicBullet>().player = player;
    }

    bool CheckFire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            return true;
        }
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public int level = 1;
    public float shieldCooldown = 5f;
    public bool shieldActive = true;
    public GameObject shieldPrefab;
    public int health = 0;
    // Start is called before the first frame update
    void Start()
    {
        health = level;
    }

    // Update is called once per frame
    void Update()
    {
        if (!shieldActive)
        {
            shieldCooldown -= Time.deltaTime;
            if (shieldCooldown <= 0)
            {
                shieldCooldown = 5f;
                shieldActive = true;
                shieldPrefab.SetActive(true);
                health = level;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Projectile")
        {
            health--;
            if (health <= 0)
            {
                shieldActive = false;
                shieldPrefab.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHandler : MonoBehaviour
{
    public GameObject boss;
    public GameObject player;
    public List<GameObject> minions = new List<GameObject>();

    public int life = 100;
    public int maxLife = 100;
    public int level = 1;

    public float spawnRate = 5.0f;
    public float spawnTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0.0f;
            spawnMinion();
        }
    }

    public void spawnMinion()
    {
        GameObject minion = Instantiate(minions[Random.Range(0, minions.Count)], boss.transform.position, Quaternion.identity);
        minion.GetComponent<EnemyHandler>().player = player;
    }

    public void takeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().takeDamage(10);
        }
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            takeDamage(player.GetComponent<PlayerStats>().damage);
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            takeDamage(player.GetComponent<PlayerStats>().damage);
            Destroy(collision.gameObject);
        }
    }
}

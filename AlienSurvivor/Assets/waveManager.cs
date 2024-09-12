using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public List<GameObject> Bosses = new List<GameObject>();

    public List<GameObject> Spawners = new List<GameObject>();

    public List<GameObject> SpawnedEnemies = new List<GameObject>();

    public GameObject player;

    public int waveNumber = 0;
    public int waveSize = 0;
    public int waveSizeIncrease = 2;

    public int waveBoss = 0;
    public int waveBossIncrease = 1;

    public float waveDelay = 5.0f;

    public bool waveCleared = true;
    private bool bossSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waveCleared == true && waveDelay <= 0)
        {
            StartWave();
            waveDelay = 5.0f;
            waveCleared = false;
        } else if (waveCleared == true)
        {
            waveDelay -= Time.deltaTime;
        }

        if (SpawnedEnemies.Count == 0 && waveCleared == false && bossSpawned == false)
        {
            SpawnBoss();
        }

        if (SpawnedEnemies.Count == 0 && bossSpawned == true)
        {
            waveCleared = true;
            bossSpawned = false;
        }

        for (int i = 0; i < SpawnedEnemies.Count; i++)
        {
            if (SpawnedEnemies[i] == null)
            {
                SpawnedEnemies.RemoveAt(i);
                if (bossSpawned == true)
                {
                    player.GetComponent<PlayerStats>().experience += 5;
                } else
                    player.GetComponent<PlayerStats>().experience += 1;
            }
        }
    }

    public void StartWave()
    {
        waveNumber++;
        waveSize += waveSizeIncrease;
        waveBoss += waveBossIncrease;

        for (int i = 0; i < waveSize; i++)
        {
            int random = Random.Range(0, Spawners.Count);
            int randomEnemy = Random.Range(0, Enemies.Count);
            GameObject enemy = Instantiate(Enemies[randomEnemy], Spawners[random].transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyHandler>().player = player;
            enemy.GetComponent<EnemyHandler>().damage += waveNumber * 5;
            enemy.GetComponent<EnemyHandler>().health *= waveNumber;
            enemy.GetComponent<EnemyHandler>().attackCooldown /= waveNumber;
            enemy.GetComponent<EnemyHandler>().speed += waveNumber / 10;
            SpawnedEnemies.Add(enemy);
        }
    }


    public void SpawnBoss()
    {
        for (int i = 0; i < waveBoss; i++)
        {
            int random = Random.Range(0, Spawners.Count);
            int randomBoss = Random.Range(0, Bosses.Count);
            GameObject boss = Instantiate(Bosses[randomBoss], player.transform.position + new Vector3(10, 10, 0), Quaternion.identity);
            boss.GetComponent<bossHandler>().player = player;
            boss.GetComponent<bossHandler>().maxLife *= waveNumber * 2;
            boss.GetComponent<bossHandler>().level = waveNumber;
            SpawnedEnemies.Add(boss);
        }
        bossSpawned = true;
    }
}

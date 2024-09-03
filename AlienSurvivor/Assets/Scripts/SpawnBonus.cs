using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    public List<GameObject> bonuses = new List<GameObject>();
    public Vector2 spawnRange = new Vector2(5, 5);

    void OnDestroy()
    {
        spawn();
    }

    void spawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(transform.position.x - spawnRange.x, transform.position.x + spawnRange.x), Random.Range(transform.position.y - spawnRange.y, transform.position.y + spawnRange.y));
        GameObject bonus = bonuses[Random.Range(0, bonuses.Count)];
        Instantiate(bonus, spawnPosition, Quaternion.identity);
    }
}

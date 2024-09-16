using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalStrike : MonoBehaviour
{
    public GameObject strikePrefab;
    public float strikeCooldown = 5f;
    public float strikeDuration = 1f;
    public float areaOfEffect = 5f;
    public GameObject player;
    public int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        strikeCooldown -= Time.deltaTime;
        if (strikeCooldown <= 0)
        {
            strikeCooldown = 5f;
            for (int i = 0; i < level; i++)
                Strike();
        }
    }

    void Strike()
    {
        Vector3 strikePosition = player.transform.position + new Vector3(Random.Range(player.transform.position.x - areaOfEffect, player.transform.position.x + areaOfEffect), Random.Range(player.transform.position.y - areaOfEffect, player.transform.position.y + areaOfEffect), 0);
        GameObject strike = Instantiate(strikePrefab, strikePosition, Quaternion.identity);
        Destroy(strike, strikeDuration);
    }
}

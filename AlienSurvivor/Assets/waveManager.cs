using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public List<GameObject> Bosses = new List<GameObject>();

    public List<GameObject> Spawners = new List<GameObject>();

    public List<GameObject> SpawnedEnemies = new List<GameObject>();

    public int waveNumber = 0;
    public int waveSize = 0;
    public int waveSizeIncrease = 5;

    public int waveBoss = 0;
    public int waveBossIncrease = 1;

    public float waveDelay = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

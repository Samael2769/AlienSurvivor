using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Vector2 spawnRange = new Vector2(0, 0);
    public Vector2 center = new Vector2(0, 0);
    public Vector4 MaxCoordinates = new Vector4(0, 0, 0, 0);
    public List<GameObject> objectsToSpawn = new List<GameObject>();
    private List<GameObject> spawnedObjects = new List<GameObject>();
    public bool updateSpawn = true;
    public int maxObjects = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxObjects; i++)
        {
            SpawnObject();
        }
        Debug.Log(spawnedObjects.Count);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            if (spawnedObjects[i] == null)
            {
                spawnedObjects.RemoveAt(i);
            }
        }
        if (updateSpawn)
        {
            if (spawnedObjects.Count < maxObjects)
            {
                SpawnObject();
            }
        }
    }

    void SpawnObject()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(center.x - spawnRange.x, center.x + spawnRange.x), Random.Range(center.y - spawnRange.y, center.y + spawnRange.y));
        if (spawnPosition.x < MaxCoordinates.x || spawnPosition.x > MaxCoordinates.y || spawnPosition.y < MaxCoordinates.z || spawnPosition.y > MaxCoordinates.w)
        {
            return;
        }
        GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Count)];
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        spawnedObjects.Add(spawnedObject);
    }
}

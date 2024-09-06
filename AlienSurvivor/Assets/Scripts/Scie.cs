using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scie : MonoBehaviour
{
    public int level = 1;
    public GameObject bulletPrefab;
    public GameObject player;
    private int scieNb = 0;

    public List<GameObject> bullets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < level; i++)
        {
            GameObject bull = (GameObject)Instantiate(
                bulletPrefab,
                transform.position + new Vector3(1 + 0.2f * i, 0, 0),
                transform.rotation * Quaternion.Euler(0, 0, 0)
                );
            bull.GetComponent<ScieBullet>().speed = 100 + 50 * i;
            bull.GetComponent<ScieBullet>().player = player;
            bull.transform.parent = transform;
            bullets.Add(bull);
            scieNb++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //lock rotation
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (scieNb < level)
        {
            addScie();
            scieNb++;
        }
    }

    void addScie()
    {
        GameObject bull = (GameObject)Instantiate(
            bulletPrefab,
            transform.position + new Vector3(1 + 0.2f * level, 0, 0),
            transform.rotation * Quaternion.Euler(0, 0, 0)
            );
        bull.GetComponent<ScieBullet>().speed = 100 + 50 * level;
        bull.GetComponent<ScieBullet>().player = player;
        bull.transform.parent = transform;
        bullets.Add(bull);
    }

}

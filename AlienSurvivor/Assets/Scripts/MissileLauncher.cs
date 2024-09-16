using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{

    public GameObject player;

    public GameObject missileFollow;
    public GameObject missileStraight;

    private int[] pattern = { 0, 0, 0, 1, 1, 0, 0, 1};
    private int patternIndex = 0;

    public float fireRate = 0.5f;
    private float fireTimer = 0.0f;

    private int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.GetComponent<bossHandler>().player;
        level = this.gameObject.GetComponent<bossHandler>().level;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireTimer >= fireRate)
        {
            fireTimer = 0.0f;
            fireMissile();
        }
        fireTimer += Time.deltaTime;
    }
    
    public void fireMissile()
    {
        GameObject missile = null;
        if (pattern[patternIndex] == 0)
        {
            missile = Instantiate(missileStraight, transform.position, Quaternion.identity);
            missile.GetComponent<MissileHandler>().direction = player.transform.position - transform.position;
            missile.GetComponent<MissileHandler>().damage = 10 * level;
            missile.GetComponent<MissileHandler>().speed += level / 10;
        }
        else if (pattern[patternIndex] == 1)
        {
            missile = Instantiate(missileFollow, transform.position, Quaternion.identity);
            missile.GetComponent<MissileHandler>().player = player;
            missile.GetComponent<MissileHandler>().damage = 5 * level;
            missile.GetComponent<MissileHandler>().speed += level / 10;
            missile.GetComponent<MissileHandler>().lifeTime += level / 5;
        }
        patternIndex++;
        if (patternIndex >= pattern.Length)
        {
            patternIndex = 0;
        }
    }

}
